import React, { useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { Link, useNavigate } from "react-router-dom";
import { AiOutlineHeart } from 'react-icons/ai';
import Swal from "sweetalert2";
import { LoginWarning } from "../LoginWarning";
import userManager from "../../../app/UserManager";
import { addProductToCart } from "../../../app/Actions/Index";
//Her bir ürünü temsil edecek
const ProductCard = (props) => {
    let dispatch = useDispatch();
    let status = useSelector((state) => state.user.status);
    let user = useSelector((state) => state.user.user);

    const login = () => {

        userManager.signinRedirect({
            data: { path: "/" },
        });
    };
    const sepeteEkle = async (product) => {

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

    const favorilereEkle = async (id) => {
        dispatch({ type: "products/addToFavorites", payload: { id } })
    }
    return (
        <>
            <div className="product_wrappers_one">
                <div className="thumb">
                    <Link to={`/product-details-two/${props.data.productId}`} className="image">
                        <img src={props.data.imageUrl} alt={props.data.name}></img>

                    </Link>
                    <span className="badges">
                        <span className={(['yaz', 'yeni', 'satışta'][Math.round(Math.random() * 2)])} >
                            {props.data.categoryName}
                        </span>
                    </span>
                    <div className="actions">
                        <a href="#!" className="action wishlist" title="Favorilere Ekle"
                            onClick={() => favorilereEkle(props.data.productId)} ><AiOutlineHeart />

                        </a>
                    </div>
                    <button type="button" className="add-to-cart offcanvas-toggle"
                        onClick={() => sepeteEkle(props.data)} >Sepete Ekle</button>
                </div>
                <div className="content">
                    <h5 className="title">
                        <Link to={`/product-details-two/${props.data.productId}`}>{props.data.name}</Link>
                    </h5>
                    <span className="price">
                        <span className="new">{props.data.price} TL</span>
                    </span>
                </div>

            </div>
        </>
    )
}

export default ProductCard