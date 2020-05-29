var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btn-edit').off('click').on('click', function () {
            var listProduct = $('.inputSoLuong');
            var cartList = [];

            $.each(listProduct, function (i, item) {
                cartList.push({
                    SoLuong: $(item).val(),
                    MonAn: {
                        MaMon: $(item).data('id')
                    }
                });
            });

            //goi ajax
            $.ajax({
                url: '/CartShop/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/cap-nhap-gio-hang";
                    }
                }
            })
        });
        
        $('.btn-delete-product').off('click').on('click', function () {
            //goi ajax xoa sp
            $.ajax({
                url: '/CartShop/Delete',
                data: { id: $(this).data('id') },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/cap-nhap-gio-hang";
                    }
                }
            })
        });
    }
}

cart.init();