import React from 'react'
import BanImg from '../../../assets/img/common/man.png'
import { Link } from 'react-router-dom'

const Banner = () => {
    return (
        <>
            <section id="banner_one">
                <div className="container">
                    <div className="row">
                        <div className="col-lg-6 banner-col">
                            <div className="banner_text_one">
                                <h1 className="wow flipInX" data-wow-duration="3.0s" data-wow-delay=".3s">
                                    KARDEŞLER
                                    <span className="wow flipInX"
                                        data-wow-duration="2.0s" data-wow-delay=".5s">PİDE KEBAP</span>
                                </h1>
                                <a href='#hot-Product_area' className="theme-btn-one btn_md">Gözat</a>
                            </div>
                        </div>
                        {/* <div className="col-lg-6">
                            <div className="hero_img" >
                                <img src={BanImg} alt="img" />
                            </div>
                        </div> */}
                    </div>
                </div>
            </section>
        </>

    )
}

export default Banner
