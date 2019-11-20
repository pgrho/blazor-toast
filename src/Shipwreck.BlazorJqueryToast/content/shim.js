var Shipwreck;
(function () {
    Shipwreck = Shipwreck || (Shipwreck = {});
    Shipwreck.blazorJqueryToast = function (p) {
        jQuery.toast(JSON.parse(p));
    };
})(jQuery);