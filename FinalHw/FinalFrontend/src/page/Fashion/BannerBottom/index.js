import React from "react";
import { Link } from "react-router-dom";

import img1 from '../../../assets/img/offer/woman.png';
import img2 from '../../../assets/img/offer/woman1.png';
import img3 from '../../../assets/img/offer/bag.png';
import img4 from '../../../assets/img/offer/woman4.png';
import img5 from '../../../assets/img/offer/kids.png';

const BannerBottom = () => {
    return (
        <>
            <section id="product_variation_one" className="pt-100">
                <div className="container_fluid">
                    <div className="row">
                        <div className="col-lg-4 col-md-6">
                            <div className="product_variation_one_boxed img-zoom-hover">
                                <img src={img1} alt="img" />
                                <div className="product_var_one_text">
                                    <h4 className="color_one">Glutensiz</h4>
                                    <h2>Yeni</h2>
                                    <h4>Lezzetler</h4>
                                    <Link to="/shop" className="theme-btn-one bg-black btn-sm">Satın Al</Link>
                                </div>
                            </div>
                            <div className="product_variation_one_boxed img-zoom-hover">
                                <img src={img2} alt="img" />
                                <div className="product_var_two_text">
                                    <h4 className="color_one">Eşsiz</h4>
                                    <h2>En Sevilen</h2>
                                    <h4>Tatlılar</h4>
                                    <Link to="/shop" className="theme-btn-one bg-black btn-sm">Gözat</Link>
                                </div>
                            </div>
                        </div>
                        <div className="col-lg-4 col-md-6">
                            <div className="product_variation_one_boxed img-zoom-hover">
                                <img src={img3} alt="img" />
                                <div className="product_var_one_text_center">
                                    <h2 className="color_two">%40 İndirim</h2>
                                    <h4>Üyelere Özel</h4>
                                    <Link to="/shop" className="theme-btn-one bg-black btn-sm">Gözat</Link>
                                </div>
                            </div>
                        </div>
                        <div className="col-lg-4 col-md-6">
                            <div className="product_variation_one_boxed img-zoom-hover">
                                <img src={img4} alt="img" />
                                <div className="product_var_one_text_center">
                                    <h2 className="color_three">Lezziz</h2>
                                    <h4>Atıştırmalıklar</h4>
                                    <Link to="/shop" className="theme-btn-one bg-black btn-sm">Gözat</Link>
                                </div>
                            </div>
                            <div className="product_variation_one_boxed img-zoom-hover">
                                <img src={img5} alt="img" />
                                <div className="product_var_one_text_center">
                                    <h2 className="color_four">Diyetisyenin Elinden</h2>
                                    <h4>Dengeli Seçenekler</h4>
                                    <Link to="/shop" className="theme-btn-one bg-black btn-sm">Gözat</Link>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </>
    )
}
export default BannerBottom