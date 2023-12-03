import { createAsyncThunk } from '@reduxjs/toolkit';
import axios from 'axios';

export const getAllProducts = createAsyncThunk('products/getAllProducts', async () => {

  const response = await axios.get('https://localhost:5050/api/products')
    .catch(error => {

      throw error; // Throw the error again to trigger the rejection of the promise
    });

  return response.data.result;
});

export const getUserCart = createAsyncThunk('products/getUserCart', async (userId) => {

  try {
    const response = await axios.get(`https://localhost:5050/api/cart/GetCart/${userId}`)
    const data = await response.data
    if (data.isSuccess) {
      const cart = data.result
      if (cart.cartHeader) {

        // get discount if coupon applied
        let discountAmount = 0
        if (cart.cartHeader.couponCode !== "") {
          const couponResponse = await axios.get(`https://localhost:5050/api/coupon/${cart.cartHeader.couponCode}`)
          const couponData = await couponResponse.data

          if (couponData.isSuccess) {
            discountAmount = +couponData.result.discountAmount
          }
        }

        cart.cartHeader.discountTotal = discountAmount
        cart.cartHeader.orderTotal = 0
        cart.cartDetails.forEach(detail => {
          cart.cartHeader.orderTotal += +detail.product.price * +detail.count
        });
        cart.cartHeader.orderTotal -= discountAmount
      }


      return cart
    }
    return null
  } catch (error) {

    throw error;
  }
});

export const getUserFavorites = createAsyncThunk('products/getUserFavorites', async (userId) => {

  try {
    const response = await axios.get(`https://localhost:5050/api/favorite/${userId}`)
    const data = await response.data

    return data.result
  } catch (error) {

    throw error;
  }

});

export const getCategories = createAsyncThunk('products/getCategories', async () => {

  try {
    const response = await axios.get(`https://localhost:5050/api/products/categories`)
    const data = await response.data

    return data.result
  } catch (error) {

    throw error;
  }

});

export const getProductById = createAsyncThunk('products/getProductById', async (productId) => {

  try {
    const response = await axios.get(`https://localhost:5050/api/products/${productId}`)
    const data = await response.data

    return data.result
  } catch (error) {

    throw error;
  }

});

export const addProductToCart = createAsyncThunk('products/addProductToCart', async (cartBody) => {

  try {

    const response = await axios.post(`https://localhost:5050/api/cart`, cartBody)
    const data = await response.data

    return data.result
  } catch (error) {

    throw error;
  }

});

export const deleteProductFromCart = createAsyncThunk('products/deleteProductFromCart', async (deletedCartDetailId) => {
  try {

    const response = await axios.post(`https://localhost:5050/api/cart/RemoveCart/${deletedCartDetailId}`)
    const data2 = await response.data

    if (data2.isSuccess && data2.result) {
      return deletedCartDetailId
    }

  } catch (error) {

    throw error;
  }

});

export const sendOrder = createAsyncThunk('products/sendOrder', async (checkoutHeader) => {
  try {

    const response = await axios.post(`https://localhost:5050/api/cartc`, checkoutHeader)
    const data2 = await response.data

    return data2

  } catch (error) {

    throw error;
  }

});

export const getUserOrders = createAsyncThunk('products/getUserOrders', async (userId) => {
  try {

    const response = await axios.get(`https://localhost:5050/api/order/${userId}`)
    const data2 = await response.data

    return data2.result

  } catch (error) {

    throw error;
  }

});