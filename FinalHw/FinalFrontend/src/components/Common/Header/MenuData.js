export const MenuData = [
    {
        name: "Kategoriler",
        href: "#!",
        children: [
            {
                name: "Filtrele",
                href: "/shop/shop-left-sidebar"
            },

        ],
        isAuthRequired: false
    },
    {
        name: "Hakkımızda",
        href: "#!",
        children: [
            {
                name: "Biz Kimiz",
                href: "/about"
            }
        ],
        isAuthRequired: false
    },
    {
        name: "Bize Ulaşın",
        href: "#!",
        children: [
            {
                name: "Adresimiz",
                href: "/contact"
            }
        ],
        isAuthRequired: false
    },
    {
        name: "Hesabım",
        href: "#!",
        children: [
            {
                name: "Siparişlerim",
                href: "/my-account/customer-order"
            }
        ],
        isAuthRequired: true
    }
]