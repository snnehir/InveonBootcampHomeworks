import React, { useEffect, useState } from 'react'
// Import Img
import search from '../../assets/img/svg/search.svg'
import { useSelector } from 'react-redux'


const SideBar = (props) => {

    const categories = useSelector(state => state.products.categories) || []


    const [price, setPrice] = useState(100)
    const [category, setCategory] = useState("-1")
    const [searchTerm, setsearchTerm] = useState("")
    const handleFiltering = (newCategory, newPrice, search) => {
        setPrice(newPrice);
        setCategory(newCategory)
        setsearchTerm(search)
        props.filterEvent(newCategory, newPrice, search);
    }




    return (
        <>
            <div className="col-lg-3">
                <div className="shop_sidebar_wrapper">
                    {/* todo: fix search */}
                    <div className="shop_Search">
                        <form>
                            <input type="text" className="form-control" placeholder="Ara..." value={searchTerm} onChange={(e) => { handleFiltering(category, price, e.target.value) }} />
                            <button><img src={search} alt="img" /></button>
                        </form>
                    </div>
                    {/* TODO: product api => category controller => category repository */}
                    <div className="shop_sidebar_boxed">
                        <h4>Ürün Kategorileri</h4>
                        <form>
                            <label className="custom_boxed">Tümü
                                <input type="radio" name="radio" defaultChecked value={"-1"} onChange={() => handleFiltering("-1", price, searchTerm)} />
                                <span className="checkmark"></span>
                            </label>

                            {categories.map((category, index) => {
                                return (
                                    <label key={index} className="custom_boxed">{category.categoryName}
                                        <input type="radio" name="radio" value={category.categoryId} onChange={() => handleFiltering(`${category.categoryId}`, price, searchTerm)} />
                                        <span className="checkmark"></span>
                                    </label>
                                )
                            })
                            }

                        </form>
                    </div>
                    <div className="shop_sidebar_boxed">
                        <h4>Fiyat</h4>
                        <div className="price_filter">
                            <input type="range" min="5" max="200" defaultValue={price} className="form-control-range" id="formControlRange"
                                onChange={(e) => handleFiltering(category, e.target.value, searchTerm)}
                            />
                            <div className="price_slider_amount mt-2">
                                <span>Fiyat : {price}</span>
                            </div>
                        </div>
                    </div>
                    {/** todo: rating? */}
                </div>
            </div>
        </>
    )
}

export default SideBar
