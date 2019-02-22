// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

(function ($) {

    jQuery(function ($) {

        //Fade in alerts that are marked as show on page load
        if (!$('.alert.show-on-load.fade').hasClass('in')) {
            $('.alert.show-on-load.fade').addClass('in');
        }

        $(".alert.dismiss").fadeTo(2000, 500).slideUp(500, function () {
            $(".alert.dismiss").slideUp(500);
        });

        $('.confirmation-modal').on('show.bs.modal', function (e) {
            var $invoker = $(e.relatedTarget);
            $(this).find("#confirm").attr('data-form', $invoker.attr('data-form'));
        });

        $('.confirmation-modal #confirm').on('click', function (e) {
            var $form = $($(this).attr('data-form'));

            if ($.isFunction($form.valid)) {
                if ($form.valid()) {
                    $form.submit();
                }
            }
            else {
                $form.submit();
            }
        });
    });

}());