import ProductInfo from './ProductInfo'
import RelatedProduct from './RelatedProduct'
import { Link } from 'react-router-dom'
import { useEffect, useState } from 'react'
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import Slider from "react-slick";
import { useSelector, useDispatch } from "react-redux";
import { useParams } from 'react-router-dom';
import { RatingStar } from "rating-star";
import { addProductToCart, getProductById } from '../../../app/Actions/Index';
import userManager from '../../../app/UserManager';
import Swal from 'sweetalert2';

const ProductDetailsTwo = () => {
    let dispatch = useDispatch();
    let { id } = useParams();
    let status = useSelector((state) => state.user.status);
    let user = useSelector((state) => state.user.user);

    const login = () => {
        // pass the current path to redirect to the correct page after successfull login
        userManager.signinRedirect({
            data: { path: "/" },
        });
    };

    useEffect(() => {
        dispatch(getProductById(id));
    }, [id])

    const product = useSelector((state) => state.products.single)


    // Add to cart
    const sepeteEkle = async () => {


        if (status && user) {

            const cartBody = {
                cartHeader: {
                    userId: user.user_id

                },
                cartDetails: [
                    {
                        product: product,
                        productId: product.productId,
                        count: 1
                    }

                ]
            }

            dispatch(addProductToCart(cartBody))
            Swal.fire('Ürün sepetinize başarıyla eklendi!', '', 'success')
        }

        else {
            Swal.fire({
                title: "Oturum Açmadınız",
                text: "Sepete ürün eklemek için giriş yapmalısınız.",
                showCancelButton: true,
                confirmButtonText: 'Giriş Yap',
                cancelButtonText: "İptal",
                customClass: {
                    actions: 'my-actions',
                    cancelButton: 'order-1 right-gap',
                    confirmButton: 'order-2',
                },
            }).then((result) => {
                if (result.isConfirmed) {
                    login()
                }
            })
        }

    }

    // Add to Favorite
    const addToFav = async (id) => {
        dispatch({ type: "products/addToFavorites", payload: { id } })
    }


    return (
        <>{product
            ?
            <section id="product_single_two" className="ptb-100">
                <div className="container">
                    <div className="row area_boxed">
                        <div className="col-lg-4">
                            <div className="product_single_two_img slider-for">
                                <div className="product_img_two_slider">
                                    <img src={product.imageUrl} alt="img" />
                                </div>
                            </div>

                        </div>
                        <div className="col-lg-8">
                            <div className="product_details_right_one">
                                <div className="modal_product_content_one">
                                    <h3>{product.name}</h3>

                                    <h4>{product.price} TL</h4>
                                    <p>{product.description}</p>

                                    <div className="links_Product_areas">
                                        <ul>
                                            <li>
                                                <a href="#!" className="action wishlist" title="Wishlist" onClick={() => addToFav(product.id)}><i
                                                    className="fa fa-heart"></i>Favorilere Ekle</a>
                                            </li>

                                        </ul>
                                        <a href="#!" className="theme-btn-one btn-black-overlay btn_sm"
                                            onClick={() => sepeteEkle()}>Sepete Ekle</a>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                    {/* <ProductInfo /> */}
                </div>
            </section>
            :
            <>
                <div className="container ptb-100">
                    <div className="row">
                        <div className="col-lg-6 offset-lg-3 col-md-6 offset-md-3 col-sm-12 col-12">
                            <div className="empaty_cart_area">

                                <h2>Ürün Bulunamadı</h2>
                                <Link to="/shop/shop-left-sidebar" className="btn btn-black-overlay btn_sm">Alışverişe Devam</Link>
                            </div>
                        </div>
                    </div>


                </div>

            </>

        }

            <RelatedProduct />

        </>
    )
}

export default ProductDetailsTwo