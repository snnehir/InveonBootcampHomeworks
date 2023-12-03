import React from 'react'
import ProductCard from '../Product/ProductCard'
import { useSelector } from "react-redux";
import Heading from '../../../page/Fashion/Heading';
const RelatedProduct = () => {
    let productData = useSelector((state) => state.products.products) || []
    // categoryId = 5 => içecekler
    const products = [...productData].filter(p => p.categoryId !== "5").sort(() => 0.5 - Math.random());
    return (
        <>
            <section id="related_product" className="pb-100">
                <div className="container">
                    <h5 className='mb-4'>Sevebileceğiniz diğer lezzetler</h5>
                    <div className="row">
                        {products.slice(0, 4).map((data, index) => (
                            <div className="col-lg-3 col-md-4 col-sm-6 col-12" key={index} >
                                <ProductCard data={data} />
                            </div>
                        ))}
                    </div>
                </div>
            </section>
        </>
    )
}

export default RelatedProduct