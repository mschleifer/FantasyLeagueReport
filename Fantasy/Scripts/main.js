import Flickity from 'flickity'

(function () {

    // Global export
    window.flickity = {
        init: function (elementId) {
            var elem = document.querySelector(`#${elementId}`);
            var flkty = new Flickity(elem, {
                freeScroll: true,
                pageDots: false,
                cellAlign: 'left'
            });
        }
    };
})();

window.prefersDarkMode = function () {
    return window.matchMedia('(prefers-color-scheme: dark)').matches;
}