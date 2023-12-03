import React, { useEffect, useState } from 'react'
import SideBar from './SideBar'
import ProductCard from '../Common/Product/ProductCard'
import { useSelector } from "react-redux";
const LeftSideBar = () => {

    const [allProducts, setAllProducts] = useState(useSelector((state) => state.products.products) || [])


    const [filteredProducts, setFilteredProducts] = useState(allProducts)
    const totalProducts = filteredProducts.length
    const productsPerPage = 4
    const totalPageCount = Math.ceil(totalProducts / productsPerPage)
    const totalPages = []
    for (let currentPage = 0; currentPage < totalPageCount; currentPage++) {

        totalPages.push(currentPage + 1)
    }
    const [page, setPage] = useState(1)


    const [slicedProducts, setSlicedProducts] = useState(filteredProducts.slice(0, productsPerPage))

    const randProduct = (currentPage) => {
        if (currentPage) {
            const startIndex = (currentPage - 1) * productsPerPage;
            const endIndex = startIndex + productsPerPage;
            const data = filteredProducts.slice(startIndex, endIndex);
            setPage(currentPage);
            setSlicedProducts(data)
        }
    }

    const filterEvent = (categoryId, maxPrice, searchTerm) => {
        let productList = []
        if (categoryId === "-1") {
            productList = allProducts.filter(p => p.price <= maxPrice && p.name.toUpperCase().includes(searchTerm.toUpperCase()))
        }

        else
            productList = allProducts.filter(p => p.categoryId === categoryId && p.price <= maxPrice && p.name.toUpperCase().includes(searchTerm.toUpperCase()))
        setFilteredProducts(productList)
        const data = productList.slice(0, productsPerPage);
        setPage(1);
        setSlicedProducts(data)
    }

    return (
        <>
            <section id="shop_main_area" className="ptb-100">
                <div className="container">
                    <div className="row">
                        <SideBar filterEvent={filterEvent} />
                        <div className="col-lg-9">
                            <div className="row">
                                {slicedProducts.slice(0, productsPerPage).map((data, index) => (
                                    <div className="col-lg-4 col-md-4 col-sm-6 col-12" key={index}>
                                        <ProductCard data={data} />
                                    </div>
                                ))}
                                <div className="col-lg-12">
                                    <ul className="pagination">
                                        <li className="page-item" onClick={(e) => { randProduct(page > 1 ? page - 1 : 0) }}>
                                            <a className="page-link" href="#!" aria-label="Previous">
                                                <span aria-hidden="true">«</span>
                                            </a>
                                        </li>


                                        {totalPages.map(currentPage =>
                                            <li key={currentPage} className={"page-item " + (page === currentPage ? "active" : null)} onClick={(e) => { randProduct(currentPage) }}>
                                                <a className="page-link" href="#!">{currentPage}</a></li>
                                        )}

                                        <li className="page-item" onClick={(e) => { randProduct(page < totalPageCount ? page + 1 : 0) }}>
                                            <a className="page-link" href="#!" aria-label="Next">
                                                <span aria-hidden="true">»</span>
                                            </a>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </>
    )
}

export default LeftSideBar
