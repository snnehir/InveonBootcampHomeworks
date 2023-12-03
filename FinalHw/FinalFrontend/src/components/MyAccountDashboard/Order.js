import moment from 'moment/moment'
import "moment/min/locales"
import React from 'react'
import { useDispatch, useSelector } from 'react-redux'
import { Link } from 'react-router-dom'

const locale = "tr" // get user's language
moment.locale(locale)

const Order = () => {
    const orders = useSelector(state => state.products.orders)

    return (
        <>
            <div className="myaccount-content">
                <h4 className="title">Siparişlerim </h4>
                {orders && orders.length > 0 ?
                    <div className="table_page table-responsive">
                        <table>
                            <thead>
                                <tr>
                                    <th>Sipariş No.</th>
                                    <th>Tarih</th>
                                    <th>Durum</th>
                                    <th>Toplam</th>
                                    <th></th>
                                </tr>
                            </thead>

                            <tbody>

                                {orders.map(order => (
                                    <tr key={order.orderHeaderId}>
                                        <td>{order.orderHeaderId}</td>
                                        <td>{moment(order.orderTime).format("DD MMMM YYYY hh:mm")}</td>
                                        <td><span className="badge badge-info">Tamamlandı</span></td>
                                        <td>{order.orderTotal}TL</td>
                                        <td><Link to="/my-account/order-detail" className="view">Görüntüle</Link></td>
                                    </tr>
                                ))}
                            </tbody>
                        </table>
                    </div>
                    :
                    <div>
                        <span>Sipariş bulunamadı.</span>
                    </div>

                }

            </div>
        </>
    )
}

export default Order
