﻿using Inveon.Services.OrderAPI.Messages;
using Inveon.Services.OrderAPI.Models;
using Inveon.Services.OrderAPI.RabbitMQSender;
using Inveon.Services.OrderAPI.Repository;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;

namespace Inveon.Services.OrderAPI.Messaging
{
	public class RabbitMQCheckoutConsumer : BackgroundService
	{
		private readonly OrderRepository _orderRepository;
		private IConnection _connection;
		private IModel _channel;
		private readonly IRabbitMQOrderMessageSender _rabbitMQOrderMessageSender;

		public RabbitMQCheckoutConsumer(OrderRepository orderRepository, IRabbitMQOrderMessageSender rabbitMQOrderMessageSender)
		{
			_orderRepository = orderRepository;
			_rabbitMQOrderMessageSender = rabbitMQOrderMessageSender;
			var factory = new ConnectionFactory
			{
				HostName = "localhost",
				UserName = "guest",
				Password = "guest"
			};

			try
			{
				_connection = factory.CreateConnection();
				_channel = _connection.CreateModel();
				_channel.QueueDeclare(queue: "checkoutqueue", false, false, false, arguments: null);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");
			}
		}
		protected override Task ExecuteAsync(CancellationToken stoppingToken)
		{
			stoppingToken.ThrowIfCancellationRequested();

			var consumer = new EventingBasicConsumer(_channel);
			consumer.Received += (ch, ea) =>
			{
				var content = Encoding.UTF8.GetString(ea.Body.ToArray());
				CheckoutHeaderDto checkoutHeaderDto = JsonConvert.DeserializeObject<CheckoutHeaderDto>(content);
				HandleMessage(checkoutHeaderDto).GetAwaiter().GetResult();

				_channel.BasicAck(ea.DeliveryTag, false);
			};
			try {
				_channel.BasicConsume("checkoutqueue", false, consumer);
			}
			catch (Exception ex) { Console.WriteLine(ex.ToString()); }


			return Task.CompletedTask;
		}

		private async Task HandleMessage(CheckoutHeaderDto checkoutHeaderDto)
		{
			OrderHeader orderHeader = new()
			{
				UserId = checkoutHeaderDto.UserId,
				FirstName = checkoutHeaderDto.FirstName,
				LastName = checkoutHeaderDto.LastName,
				OrderDetails = new List<OrderDetails>(),
				CardNumber = checkoutHeaderDto.CardNumber,
				CouponCode = checkoutHeaderDto.CouponCode,
				CVV = checkoutHeaderDto.CVV,
				DiscountTotal = checkoutHeaderDto.DiscountTotal,
				Email = checkoutHeaderDto.Email,
				ExpiryMonth = checkoutHeaderDto.ExpiryMonth,
				ExpiryYear = checkoutHeaderDto.ExpiryYear,
				OrderTime = DateTime.Now,
				OrderTotal = checkoutHeaderDto.OrderTotal,
				PaymentStatus = false,
				Phone = checkoutHeaderDto.Phone,
				PickupDateTime = checkoutHeaderDto.PickupDateTime
			};
			foreach (var detailList in checkoutHeaderDto.CartDetails)
			{
				OrderDetails orderDetails = new()
				{
					ProductId = detailList.ProductId,
					ProductName = detailList.Product.Name,
					Price = detailList.Product.Price,
					Count = detailList.Count
				};
				orderHeader.CartTotalItems += detailList.Count;
				orderHeader.OrderDetails.Add(orderDetails);
			}

			await _orderRepository.AddOrder(orderHeader);


			PaymentRequestMessage paymentRequestMessage = new()
			{
				Name = orderHeader.FirstName + " " + orderHeader.LastName,
				CardNumber = orderHeader.CardNumber,
				CVV = orderHeader.CVV,
				ExpiryMonth = orderHeader.ExpiryMonth,
				ExpiryYear = orderHeader.ExpiryYear,
				OrderId = orderHeader.OrderHeaderId,
				OrderTotal = orderHeader.OrderTotal,
				Email = orderHeader.Email
			};

			OrderMailContentMessage mailContentMessage = new() 
			{
				CardNumber = orderHeader.CardNumber,
				CartHeaderId = checkoutHeaderDto.CartHeaderId,
				Email = checkoutHeaderDto.Email,
				FirstName = orderHeader.FirstName,
				LastName = orderHeader.LastName,
				OrderTotal = orderHeader.OrderTotal,
				PickupDateTime = orderHeader.PickupDateTime
			
			};

			try
			{
				_rabbitMQOrderMessageSender.SendMessage(paymentRequestMessage, "orderpaymentprocesstopic");
				_rabbitMQOrderMessageSender.SendMessage(mailContentMessage, "orderMailqueue");
			}
			catch (Exception e)
			{
				throw;
			}
		}
	}
}
