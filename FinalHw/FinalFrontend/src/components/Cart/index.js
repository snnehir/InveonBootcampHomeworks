import React from "react";
import Coupon from './Coupon'
import TotalCart from './TotalCart'
import { Link } from 'react-router-dom'
import img from '../../assets/img/common/empty-cart.png'
import { useDispatch, useSelector } from "react-redux";
import { deleteProductFromCart } from "../../app/Actions/Index";

const CartArea = () => {
    let dispatch = useDispatch();
    let carts = useSelector((state) => state.products.carts);

    // Remove from Cart
    const rmProduct = (id) => {
        dispatch(deleteProductFromCart(id));
    }


    return (
        <>
            {carts && carts.cartDetails.length > 0
                ?
                <section id="cart_area_one" className="ptb-100">
                    <div className="container">
                        <div className="row">
                            <div className="col-lg-12 col-md-12 col-sm-12 col-12">
                                <div className="table_desc">
                                    <div className="table_page table-responsive">
                                        <table>
                                            <thead>
                                                <tr>
                                                    <th className="product_remove">Kaldır</th>
                                                    <th className="product_thumb">Resim</th>
                                                    <th className="product_name">Ürün</th>
                                                    <th className="product-price">Fiyat</th>
                                                    <th className="product_quantity">Miktar</th>
                                                    <th className="product_total">Toplam</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                {carts.cartDetails.map((data, index) => (
                                                    <tr key={index}>
                                                        <td className="product_remove">
                                                            <i className="fa fa-trash text-danger" onClick={() => rmProduct(data.cartDetailsId)} style={{ 'cursor': 'pointer' }}></i>
                                                        </td>
                                                        <td className="product_thumb">
                                                            <Link to={`/product-details-one/${data.product.productId}`}>
                                                                <img src={data.product.imageUrl} alt="img" />
                                                            </Link>
                                                        </td>
                                                        <td className="product_name">
                                                            <Link to={`/product-details-one/${data.product.productId}`}>
                                                                {data.product.name}
                                                            </Link>
                                                        </td>
                                                        <td className="product-price">{data.product.price}.00 TL</td>

                                                        <td className="product_quantity">
                                                            <span>{data.count}</span>
                                                        </td>
                                                        <td className="product_total">{data.product.price * (data.count || 1)}.00 TL</td>
                                                    </tr>
                                                ))

                                                }
                                            </tbody>
                                        </table>
                                    </div>
                                    {/* TODO: clear cart */}
                                    {/* <div className="cart_submit">
                                        {carts.length
                                            ? <button className="theme-btn-one btn-black-overlay btn_sm" type="button" onClick={() => clearCarts()}>Sepeti Temizle</button>
                                            : null
                                        }

                                    </div> */}
                                </div>
                            </div>
                            <Coupon carts={carts} />
                            <TotalCart />
                        </div>
                    </div>
                </section>
                : <section id="empty_cart_area" className="ptb-100">
                    <div className="container">
                        <div className="row">
                            <div className="col-lg-6 offset-lg-3 col-md-6 offset-md-3 col-sm-12 col-12">
                                <div className="empaty_cart_area">
                                    <img src={img} alt="img" />
                                    <h2>SEPETİNİZ BOŞ</h2>
                                    <Link to="/shop" className="btn btn-black-overlay btn_sm">Alışverişe Devam</Link>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            }
        </>
    )
}

export default CartArea