import Heading from "../Heading"
import React, { useEffect } from "react"
import { useDispatch, useSelector } from "react-redux";
import ProductCard from "../../../components/Common/Product/ProductCard";

const HotProduct = () => {
    let allProducts = useSelector((state) => state.products.products);
    let categories = useSelector((state) => state.products.categories);
    const getFilteredProducts = (categoryId) => {
        const filteredProducts = allProducts.filter(p => +p.categoryId === categoryId)
        return filteredProducts
    }
    return (
        <>
            <section id="hot-Product_area" className="ptb-100">
                <div className="container">
                    <Heading baslik="Şahane Menümüz"
                        altBaslik="Kardeşler Pide Kebap Lezzetlerini Görün" />
                    <div className="row">
                        <div className="col-lg-12">
                            <div className="tabs_center_button">
                                <ul className="nav nav-tabs">
                                    {categories && categories.map((category, index) => {
                                        return (
                                            <li key={index}>
                                                <a data-toggle="tab" className={index === 0 ? "active" : ""} href={`#${category.categoryName}`}>{category.categoryName}</a>
                                            </li>
                                        )
                                    })}
                                </ul>


                            </div>
                        </div>
                        <div className="col-lg-12">
                            <div className="tabs_el_wrapper">
                                <div className="tab-content">
                                    {categories.map((category, index) => {
                                        return (
                                            <div key={index} id={`${category.categoryName}`} className={index === 0 ? "tab-pane fade show in active" : "tab-pane fade"}>
                                                <div className="row">
                                                    {getFilteredProducts(category.categoryId).map((urun, index) => (
                                                        <div className="col-lg-3 col-md-4 col-sm-6 col-12" key={index}>
                                                            <ProductCard data={urun} />
                                                        </div>
                                                    ))}
                                                </div>
                                            </div>

                                        )
                                    })}

                                </div>
                            </div>
                        </div>
                    </div>


                </div>
            </section>
        </>
    )
}

export default HotProduct