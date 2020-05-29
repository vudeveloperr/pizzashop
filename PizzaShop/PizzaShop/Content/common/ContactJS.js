var contact = {
    init: function () {
        contact.regEvents();
    },
    regEvents: function () {
        $('#send-feedback').off('click').on('click', function () {
            var name = $('#txtName').val();
            var email = $('#txtEmail').val();
            var address = $('#txtAddress').val();
            var contentFeedback = $('#txtFeedBack').val();

            $.ajax({
                url: '/Home/Send',
                type: 'POST',
                dataType: 'json',
                data: {
                    name,
                    email,
                    address,
                    contentFeedback
                },
                success: function (res) {
                    if (res.status == true) {
                        contact.resetForm();
                        Swal.fire({
                            position: 'center',
                            icon: 'success',
                            title: 'Phản hồi của bạn đã được gửi',
                            showConfirmButton: false,
                            timer: 1500
                        });
                    }
                }
            });
        });
    },
    resetForm: function () {
        $('#txtName').val('');
        $('#txtEmail').val('');
        $('#txtAddress').val('');
        $('#txtFeedBack').val('');
    }
}

contact.init();