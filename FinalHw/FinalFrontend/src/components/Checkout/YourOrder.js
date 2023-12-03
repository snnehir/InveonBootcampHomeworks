import React from 'react'
import { Link } from "react-router-dom";
const YourOrder = (props) => {
    return (
        <>
            <div className="col-lg-6 col-md-6">
                <h3>Siparişiniz</h3>
                <div className="order_table table-responsive">
                    <table>
                        <thead>
                            <tr>
                                <th>Ürün</th>
                                <th>Adet</th>
                                <th>Toplam</th>
                            </tr>
                        </thead>
                        <tbody>
                            {props.carts && props.carts.cartDetails.map((detail, index) => (

                                <tr key={index}>
                                    <td> {detail.product.name}</td>
                                    <td> {detail.count}</td>
                                    <td> {detail.product.price} TL</td>
                                </tr>
                            ))
                            }



                        </tbody>
                        <tfoot>
                            {props.carts && props.carts.cartHeader.discountTotal > 0 &&
                                <>
                                    <tr>
                                        <th>Alt Toplam</th>
                                        <td>{props.carts.cartHeader.discountTotal + props.carts.cartHeader.orderTotal}TL</td>
                                    </tr>
                                    <tr>
                                        <th>İndirim</th>
                                        <td><strong>{props.carts.cartHeader.discountTotal} TL</strong></td>
                                    </tr>
                                </>
                            }
                            <tr className="order_total">
                                <th>Sipariş Toplamı </th>
                                <td><strong>{props.carts.cartHeader.orderTotal} TL</strong></td>
                            </tr>
                        </tfoot>
                    </table>
                </div>
                {/* <div className="payment_method">
                    <form>
                        <div className="accordion" id="accordionExample">
                            <div className="payment_area_wrappers">
                                <div className="heading_payment" id="headingOne">
                                    <div className="" data-toggle="collapse" data-target="#collapseOne" >
                                        <input type="radio" name="payment" id="html" value="HTML" defaultChecked />
                                        <label htmlFor="html">Para Transferi</label>
                                    </div>
                                </div>
                                <div id="collapseOne" className="collapse" aria-labelledby="headingOne" data-parent="#accordionExample">
                                    <div className="payment_body">
                                        <p>Direct Bank Transfer</p>
                                    </div>
                                </div>
                            </div>
                            <div className="payment_area_wrappers">
                                <div className="heading_payment" id="headingTwo">
                                    <div className="collapsed" data-toggle="collapse" data-target="#collapseTwo">
                                        <input type="radio" name="payment" id="javascript" value="JavaScript" />
                                        <label htmlFor="javascript">Mobile Bankacılık</label>
                                    </div>
                                </div>
                                <div id="collapseTwo" className="collapse" data-parent="#accordionExample">
                                    <div className="payment_body">
                                        <p>Direct Mobile Transfer</p>
                                    </div>
                                </div>
                            </div>
                            <div className="payment_area_wrappers">
                                <div className="heading_payment" id="headingThree">
                                    <div className="collapsed" data-toggle="collapse" data-target="#collapseThree">
                                        <input type="radio" name="payment" id="css" value="JavaScript" />
                                        <label htmlFor="css">Paypal</label>
                                    </div>
                                </div>
                                <div id="collapseThree" className="collapse" data-parent="#accordionExample">
                                    <div className="payment_body">
                                        <p></p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </form>

                    <div className="order_button pt-3">

                        <Link to="/order-complete" className="theme-btn-one btn-black-overlay btn_sm">
                            Sipariş Ver</Link>
                    </div>
                </div> */}
            </div>
        </>
    )
}

export default YourOrder