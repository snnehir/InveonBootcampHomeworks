import React from 'react'
import { Link } from 'react-router-dom'
import { useSelector } from "react-redux";

const TotalCart = (props) => {
    let carts = useSelector((state) => state.products.carts);

    const cartTotal = () => {

        return carts.cartDetails.reduce(function (total, item) {
            return total + ((item.count || 1) * item.product.price)
        }, 0)
    }
    return (
        <>
            {props.fullGrid ? (
                <div className="col-lg-12 col-md-12">
                    <div className="coupon_code right">
                        <h3>Toplam : </h3>
                        <div className="coupon_inner">
                            {carts.cartHeader.discountTotal > 0 &&
                                <>
                                    <div className="cart_subtotal">
                                        <p>Ara Toplam</p>
                                        <p className="cart_amount"> {cartTotal()}TL</p>
                                    </div>
                                    <div className="cart_subtotal">
                                        <p>İndirim</p>
                                        <p className="cart_amount"> {carts.cartHeader.discountTotal}TL</p>
                                    </div>
                                </>
                            }
                            <div className="cart_subtotal">
                                <p>Toplam</p>
                                <p className="cart_amount"> {carts.cartHeader.orderTotal}TL</p>
                            </div>
                            <div className="checkout_btn">

                                <Link to="/checkout-one" className="theme-btn-one btn-black-overlay btn_sm">
                                    Alışverişi Tamamla
                                </Link>
                            </div>
                        </div>
                    </div>
                </div>
            ) : (
                <div className="col-lg-6 col-md-6">
                    <div className="coupon_code right">
                        <h3>Toplam : </h3>
                        <div className="coupon_inner">
                            {carts.cartHeader.discountTotal > 0 &&
                                <>
                                    <div className="cart_subtotal">
                                        <p>Ara Toplam</p>
                                        <p className="cart_amount">{cartTotal()}TL</p>
                                    </div>
                                    <div className="cart_subtotal">
                                        <p>İndirim</p>
                                        <p className="cart_amount">{carts.cartHeader.discountTotal}TL</p>
                                    </div>
                                </>
                            }
                            <div className="cart_subtotal">
                                <p>Toplam</p>
                                <p className="cart_amount"> {carts.cartHeader.orderTotal}TL</p>
                            </div>
                            <div className="checkout_btn">

                                <Link to="/checkout-two" className="theme-btn-one btn-black-overlay btn_sm">
                                    Alışverişi Tamamla
                                </Link>
                            </div>
                        </div>
                    </div>
                </div>
            )}
        </>
    )
}

export default TotalCart
