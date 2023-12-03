import { createSlice } from "@reduxjs/toolkit";
import { getAllProducts, getUserFavorites, getCategories, getUserCart, getProductById, addProductToCart, deleteProductFromCart, sendOrder, getUserOrders } from "../Actions/Index";



const productsSlice = createSlice({
    name: 'products',
    initialState: {
        products: [],
        carts: null,
        favorites: [],
        categories: [],
        orders: [],
        single: null,
        error: null,
        loading: true
    },
    reducers: {
        AddToCart: (state, action) => {

        },

        updateCart: (state, action) => {

        },

        removeCart: (state, action) => {

        },

        clearCart: (state) => {

        },

        addToFavorites: (state, action) => {
        },

        removeToFav: (state, action) => {

        },
        clearFav: (state) => {

        },

    },
    extraReducers: (builder) => {
        builder
            .addCase(getAllProducts.pending, (state) => {
                state.loading = true;
                state.error = null;
            })
            .addCase(getAllProducts.fulfilled, (state, action) => {
                state.loading = false;
                state.products = action.payload;

            })
            .addCase(getAllProducts.rejected, (state, action) => {
                state.loading = false;
                state.error = action.error.message;

            })
            .addCase(getUserFavorites.pending, (state) => {
                state.loading = true;
                state.error = null;

            })
            .addCase(getUserFavorites.fulfilled, (state, action) => {
                state.loading = false;
                const fetchedProducts = action.payload.map(product => {
                    return {
                        id: product.productId,
                        category: product.categoryName,
                        categoryId: product.categoryId,
                        img: product.imageUrl,
                        title: product.name,
                        price: product.price,
                        description: product.description,
                        rating: {
                            rate: 3.9,
                            count: 30
                        }
                    }
                })
                state.favorites = fetchedProducts;

            })
            .addCase(getUserFavorites.rejected, (state, action) => {
                state.loading = false;
                state.error = action.error.message;

            })
            .addCase(getUserCart.pending, (state) => {
                state.loading = true;
                state.error = null;

            })
            .addCase(getUserCart.fulfilled, (state, action) => {
                state.loading = false;
                const cartHeader = action.payload
                if (cartHeader && cartHeader.cartDetails) {
                    state.carts = cartHeader;
                }

            })
            .addCase(getUserCart.rejected, (state, action) => {
                state.loading = false;
                state.error = action.error.message;

            })
            .addCase(getCategories.pending, (state) => {
                state.loading = true;
                state.error = null;

            })
            .addCase(getCategories.fulfilled, (state, action) => {
                state.loading = false;
                state.categories = action.payload || [];

            })
            .addCase(getCategories.rejected, (state, action) => {
                state.loading = false;
                state.error = action.error.message;

            })
            .addCase(getProductById.pending, (state) => {
                state.loading = true;
                state.error = null;

            })
            .addCase(getProductById.fulfilled, (state, action) => {
                state.loading = false;
                const product = action.payload
                if (product) {

                    state.single = product;
                }


            })
            .addCase(getProductById.rejected, (state, action) => {
                state.loading = false;
                state.error = action.error.message;

            })
            .addCase(addProductToCart.pending, (state) => {
                state.loading = true;
                state.error = null;

            })
            .addCase(addProductToCart.fulfilled, (state, action) => {
                state.loading = false;

                const cartDto = action.payload

                if (cartDto && cartDto.cartDetails) {
                    if (!state.carts) {
                        state.carts = {
                            cartHeader: { ...cartDto, orderTotal: 0 },
                            cartDetails: []
                        }
                    }
                    const addedProduct = cartDto.cartDetails[0]
                    if (addedProduct) {
                        const productIndex = state.carts?.cartDetails.findIndex(p => p.cartDetailsId === addedProduct.cartDetailsId)
                        if (productIndex === -1)
                            state.carts.cartDetails.push(addedProduct);
                        else {
                            state.carts.cartDetails[productIndex] = addedProduct
                        }
                        state.carts.cartHeader.orderTotal += +addedProduct.product.price

                    }
                }
            })
            .addCase(deleteProductFromCart.rejected, (state, action) => {
                state.loading = false;
                state.error = action.error.message;

            })
            .addCase(deleteProductFromCart.pending, (state) => {
                state.loading = true;
                state.error = null;

            })
            .addCase(deleteProductFromCart.fulfilled, (state, action) => {
                state.loading = false;
                const cartDetailId = action.payload
                if (cartDetailId) {
                    const removedProduct = state.carts.cartDetails.find(p => p.cartDetailsId === cartDetailId)
                    if (removedProduct) {
                        const removedProductPrice = removedProduct.product.price
                        const removedProductCount = removedProduct.count
                        state.carts.cartDetails = state.carts.cartDetails.filter(p => p.cartDetailsId !== cartDetailId)
                        state.carts.cartHeader.orderTotal -= (removedProductPrice * removedProductCount)
                    }

                }

            })
            .addCase(addProductToCart.rejected, (state, action) => {
                state.loading = false;
                state.error = action.error.message;

            })

            .addCase(sendOrder.pending, (state) => {
                state.loading = true;
                state.error = null;

            })
            .addCase(sendOrder.fulfilled, (state, action) => {
                state.loading = false;
                state.carts = null

            })
            .addCase(sendOrder.rejected, (state, action) => {
                state.loading = false;
                state.error = action.error.message;

            })

            .addCase(getUserOrders.pending, (state) => {
                state.loading = true;
                state.error = null;

            })
            .addCase(getUserOrders.fulfilled, (state, action) => {
                state.loading = false;
                state.orders = action.payload || []

            })
            .addCase(getUserOrders.rejected, (state, action) => {
                state.loading = false;
                state.error = action.error.message;

            })

    },
})


const productsReducer = productsSlice.reducer
export default productsReducer

