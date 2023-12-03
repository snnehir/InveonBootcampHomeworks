import React, { useState } from 'react'
import TopLogin from './TopLogin'
import YourOrder from './YourOrder'
import { useDispatch, useSelector } from 'react-redux';
import { sendOrder } from '../../app/Actions/Index';
import { useNavigate } from 'react-router-dom';
import Swal from 'sweetalert2';
const CheckOutTwo = () => {
    let dispatch = useDispatch();
    let carts = useSelector((state) => state.products.carts);
    const [firstName, setFirstName] = useState("")
    const [lastName, setLastName] = useState("")
    const [phone, setPhone] = useState("")
    const [email, setEmail] = useState("")
    const [cardNumber, setCardNumber] = useState("")
    const [cvv, setcCvv] = useState("")
    const [expiryMonth, setEmxpiryMonth] = useState("")
    const [expiryYear, setExpiryYear] = useState("")
    const navigate = useNavigate()

    const handleSendOrder = () => {
        if (carts) {
            let itemCount = 0
            carts.cartDetails.forEach(detail => {
                itemCount += +detail.count
            });
            const orderBody = {
                ...carts.cartHeader,
                firstName,
                lastName,
                email,
                cardNumber,
                cvv,
                expiryMonth,
                expiryYear,
                phone,
                cartTotalItems: itemCount,
                cartDetails: carts.cartDetails
            }
            dispatch(sendOrder(orderBody))
            Swal.fire('Ödeme Tamamlandı!', 'Siparişinizin durumunu siparişlerim kısmından takip edebilirsiniz.', 'success')
            navigate("/")
        }


    }
    return (
        <>
            <section id="checkout_two" className="ptb-100">
                {carts &&
                    <div className="container">
                        <div className="row">
                            {/* <TopLogin /> */}
                            <div className="col-lg-12">
                                <div className="checkout_area_two">
                                    <div className="row">
                                        <div className="col-lg-6 col-md-6">
                                            <div className="checkout_form_area">
                                                <h3>Fatura Adresi</h3>
                                                <form action="#">
                                                    <div className="row">
                                                        <div className="col-lg-6">
                                                            <div className="default-form-box">
                                                                <label >Adınız<span className="text-danger">*</span></label>
                                                                <input value={firstName} onChange={(e) => setFirstName(e.target.value)}
                                                                    type="text" className="form-control" />
                                                            </div>
                                                        </div>
                                                        <div className="col-lg-6">
                                                            <div className="default-form-box">
                                                                <label>Soyadınız <span className="text-danger">*</span></label>
                                                                <input value={lastName} onChange={(e) => setLastName(e.target.value)}
                                                                    type="text" className="form-control" />
                                                            </div>
                                                        </div>
                                                        <div className="col-lg-6">
                                                            <div className="default-form-box">
                                                                <label> Email Adresiniz<span className="text-danger">*</span></label>
                                                                <input value={email} onChange={(e) => setEmail(e.target.value)}
                                                                    type="text" className="form-control" />
                                                            </div>
                                                        </div>

                                                        <div className="col-lg-6">
                                                            <div className="default-form-box">
                                                                <label>Telefon <span className="text-danger">*</span></label>
                                                                <input value={phone} onChange={(e) => setPhone(e.target.value)}
                                                                    type="text" className="form-control" />
                                                            </div>
                                                        </div>

                                                        <div className="col-lg-6">
                                                            <div className="default-form-box">
                                                                <label>Kart Numarası <span className="text-danger">*</span></label>
                                                                <input value={cardNumber} onChange={(e) => setCardNumber(e.target.value)}
                                                                    type="text" className="form-control" />
                                                            </div>
                                                        </div>

                                                        <div className="col-lg-6">
                                                            <div className="default-form-box">
                                                                <label>CVV <span className="text-danger">*</span></label>
                                                                <input value={cvv} onChange={(e) => setcCvv(e.target.value)}
                                                                    type="text" className="form-control" />
                                                            </div>
                                                        </div>
                                                        <div className="col-lg-6">
                                                            <div className="default-form-box">
                                                                <label>Ay <span className="text-danger">*</span></label>
                                                                <input value={expiryMonth} onChange={(e) => setEmxpiryMonth(e.target.value)}
                                                                    type="text" className="form-control" />
                                                            </div>
                                                        </div>
                                                        <div className="col-lg-6">
                                                            <div className="default-form-box">
                                                                <label>Yıl<span className="text-danger">*</span></label>
                                                                <input value={expiryYear} onChange={(e) => setExpiryYear(e.target.value)}
                                                                    type="text" className="form-control" />
                                                            </div>
                                                        </div>

                                                    </div>
                                                </form>
                                            </div>
                                        </div>
                                        <>
                                            <YourOrder carts={carts} />
                                            <button onClick={handleSendOrder}>Siparişi Onayla</button>
                                        </>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                }

            </section>
        </>
    )
}

export default CheckOutTwo