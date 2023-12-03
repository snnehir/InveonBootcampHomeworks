import React, { useState } from 'react'
import { useDispatch } from 'react-redux';

const Coupon = (props) => {
    let dispatch = useDispatch();
    const [coupon, setCoupon] = useState(props.carts.cartHeader.couponCode)
    const handleCoupon = () => {

    }
    return (
        <>
            <div className="col-lg-6 col-md-6">
                <div className="coupon_code left">
                    <h3>Kupon</h3>
                    <div className="coupon_inner">
                        <p>Kupon Kodu Giriniz</p>
                        <form onSubmit={(e) => { e.preventDefault(); handleCoupon() }}>
                            <input className="mb-2" placeholder="Coupon code" type="text" required value={coupon} onChange={(e) => setCoupon(e.target.value)} />
                            <button type="submit" className="theme-btn-one btn-black-overlay btn_sm">Onayla</button>
                        </form>
                    </div>
                </div>
            </div>
        </>
    )
}

export default Coupon