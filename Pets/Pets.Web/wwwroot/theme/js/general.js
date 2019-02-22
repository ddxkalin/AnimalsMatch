/* ------------------------------------------------------------------------------------------------------------------- *
 *
 * Template Mejor - Responsive Multipurpose HTML Site Template
 * Version  1.0
 * Author   Valery Timofeev
 *
 * ------------------------------------------------------------------------------------------------------------------ */

'use strict';


function hex2RGBA(hex, opacity) {

    var r, g, b,
        hex_n = hex.replace('#', '');

    r = parseInt(hex_n.substring(0,2), 16);
    g = parseInt(hex_n.substring(2,4), 16);
    b = parseInt(hex_n.substring(4,6), 16);

    return 'rgba(' + r + ', ' + g + ', ' + b + ', ' + opacity / 100 + ')';
}



/* ------------------------------------------------------------------------------------------------------------------- *
 * Sticky Plugin
 * ------------------------------------------------------------------------------------------------------------------ */

/**
 * jQuery sticky plugin
 *
 * @version 1.0.1
 * @author  Valery Timofeev (http://vtdes.ru, spprofart@gmail.com)
 */
(function($) {

    $.fn.pfvt_sticky = function(opts) {

        // Window object
        var $window = $(window),
            // Selectors
            selectors = [],
            // Current options
            options = {},
            // Default settings
            defaults = {

                offset_top: 0,
                offset_bottom: 0,

                class_above : 'sticky-above',
                class_bellow: 'sticky-bellow',
                class_active: 'sticky-active',

                onAbove : function() {},
                onActive: function() {},
                onBellow: function() {}

            };


        function addSelector(selector) {
            selectors.push(selector);
        }

        function process() {

            for (var i = 0, l = selectors.length; i < l; i++) {

                var $sticky = $(selectors[i]).filter(function() {
                    return $(this).is(':sticky-active');
                });

                $sticky.trigger('sticky', [$sticky]);

            }

        }

        /**
         * Custom filter for element
         * @param el
         */
        $.expr[':']['sticky-active'] = function(el) {

            // UPD: el_offset_bottom = el_offset_top + $el.height(),

            var $el = $(el),
                el_offset_top = $el.offset().top + options.offset_top,
                el_offset_bottom = el_offset_top + $el.outerHeight(true) - $window.height() + options.offset_bottom,
                window_top = $window.scrollTop();

            if (window_top >= el_offset_top && window_top <= el_offset_bottom) {

                $el
                    .removeClass(options.class_above)
                    .removeClass(options.class_bellow)
                    .addClass(options.class_active);

                if (typeof options.onActive === 'function') options.onActive();
            }

            if (window_top < el_offset_top) {

                $el
                    .removeClass(options.class_above)
                    .removeClass(options.class_active)
                    .addClass(options.class_bellow);

                if (typeof options.onActive === 'function') options.onBellow();
            }

            if (window_top > el_offset_bottom) {

                $el
                    .removeClass(options.class_bellow)
                    .removeClass(options.class_active)
                    .addClass(options.class_above);

                if (typeof options.onActive === 'function') options.onAbove();
            }

        };


        options = $.extend({}, defaults, opts || {});
        var selector = this.selector || this;

        $window.scroll(process).resize(process);
        $(document).ready(process);

        addSelector(selector);
        return $(selector);
    };

})(jQuery);



/* ------------------------------------------------------------------------------------------------------------------ *
 * Main IIFE
 * ------------------------------------------------------------------------------------------------------------------ */

$(function($) {

    'use strict';



    /* -------------------------------------------------------------------------------------------------------------- *
     * Variables and Constants
     * -------------------------------------------------------------------------------------------------------------- */

    var $body_html = $('body, html'),
        $html = $('html'),
        $body = $('body');

    var THEME_COLORS = {

        PRIMARY:         '#3949ab',
        PRIMARY_LIGHT:   '#5c6bc0',
        PRIMARY_DARK:    '#303f9f',

        SECONDARY:       '#ff4081',
        SECONDARY_LIGHT: '#ff80ab',
        SECONDARY_DARK:  '#f50057',

        DARK:            '#455a64',
        LIGHT:           '#eceff1',

        DEFAULT:         '#ff4081',
        SUCCESS:         '#28a758',
        INFO:            '#209eab',
        WARNING:         '#da993f',
        DANGER:          '#d5535e'

    };



    /* -------------------------------------------------------------------------------------------------------------- *
     * Is Mobile
     * -------------------------------------------------------------------------------------------------------------- */

    var ua_test = /Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i,
        is_mobile = ua_test.test(navigator.userAgent);

    $html.addClass(is_mobile ? 'mobile' : 'no-mobile');



    /* -------------------------------------------------------------------------------------------------------------- *
     * Affix
     * -------------------------------------------------------------------------------------------------------------- */

    $('.affix').affix();



    /* -------------------------------------------------------------------------------------------------------------- *
     * Smooth Scrolling
     * -------------------------------------------------------------------------------------------------------------- */

    $('.smooth-scroll:not([href="#"])').click(function(event) {

        event.preventDefault();

        var $this = $(this),
            target = $this.attr('href');

        if (target === 'undefined') return;

        var $target = $(target);
        if ($target.length === 0) return;

        var offset = $target.offset().top || 0;

        $.scrollWindow(offset);

    });

    $.scrollWindow = function(offset) {
        $body_html.animate({ scrollTop: offset }, 750);
    };



    /* -------------------------------------------------------------------------------------------------------------- *
     * Prevent Empty Anchors
     * -------------------------------------------------------------------------------------------------------------- */

    $('a[href="#"]').click(function(event) {
        event.preventDefault();
    });



    /* -------------------------------------------------------------------------------------------------------------- *
     * Hide all sidebars on mobile and small width devices
     * -------------------------------------------------------------------------------------------------------------- */


    if (is_mobile || $(window).width() < 768) {
        $body.removeClass('dashb-01-expanded dashb-02-expanded dashb-03-expanded');
        $('#dashb-01-toggle, #dashb-02-toggle, #dashb-03-toggle').removeClass('open');
    }


    /* -------------------------------------------------------------------------------------------------------------- *
     * Dashboard-01
     * -------------------------------------------------------------------------------------------------------------- */

    $('.dashb-01-toggle').on('click', function(e) {

        e.preventDefault();
        e.stopPropagation();

        $body.toggleClass('dashb-01-expanded');
        $(this).toggleClass('open');

        if ($body.hasClass('dashb-01-expanded')) $('.navbar-collapse').collapse('hide');

    });

    var $dashb_01_toggle = $('#dashb-01-toggle');

    $('.nav-has-submenu').each(function() {

        var $this = $(this),
            $toggle_button = $this.find('> .nav-submenu-toggle');

        $toggle_button.on('click', function(e) {

            e.preventDefault();
            e.stopPropagation();

            $this.toggleClass('open');
            $this.parent().toggleClass('sub-open');

            if (!$body.hasClass('dashb-01-expanded')) {
                $body.addClass('dashb-01-expanded');
                $dashb_01_toggle.addClass('open');
                $('.tooltip').hide();
            }

        });
    });

    /*
     * Close all submenus on toggle click
     * ================================== */

    $dashb_01_toggle.on('click', function() {

        $('.nav-has-submenu.open')
            .removeClass('open')
            .parent().removeClass('sub-open');

    });

    /*
     * Initialize Tooltip to display prompts on the first level links
     * ============================================================== */

    $('[data-toggle="tooltip-dashboard"]').tooltip({
        container: 'body',
        placement: 'right',
        title: function() {
            if ($body.hasClass('dashb-01-expanded')) return '';
            return $(this).find('span').html() || '';
        }
    });



    /* -------------------------------------------------------------------------------------------------------------- *
     * Dashboard-02
     * -------------------------------------------------------------------------------------------------------------- */

    $('.dashb-02-toggle').on('click', function(e) {

        e.preventDefault();
        e.stopPropagation();

        $body.toggleClass('dashb-02-expanded');
        $(this).toggleClass('open');

        if ($body.hasClass('dashb-02-expanded')) $('.navbar-collapse').collapse('hide');
    });



    /* -------------------------------------------------------------------------------------------------------------- *
     * Dashboard-03
     * -------------------------------------------------------------------------------------------------------------- */

    $('.dashb-03-toggle').on('click', function(e) {

        e.preventDefault();
        e.stopPropagation();

        $body.toggleClass('dashb-03-expanded');
        $(this).toggleClass('open');

        if ($body.hasClass('dashb-03-expanded')) $('.navbar-collapse').collapse('hide');

    });



    /* -------------------------------------------------------------------------------------------------------------- *
     * Front page
     * -------------------------------------------------------------------------------------------------------------- */

    $('.front-toggle').on('click', function(e) {

        e.preventDefault();
        e.stopPropagation();

        $body.toggleClass('front-expanded');
        $(this).toggleClass('open');
    });



    /* -------------------------------------------------------------------------------------------------------------- *
     * Toggleable Navbar Form
     * -------------------------------------------------------------------------------------------------------------- */

    $('.navbar-form-toggleable').each(function() {

        var $form = $(this);

        $form.find('.navbar-form-toggle').on('click', function(e) {

            e.preventDefault();
            e.stopPropagation();

            $form.toggleClass('in');

        });

    });



    /* -------------------------------------------------------------------------------------------------------------- *
     * Custom input
     * -------------------------------------------------------------------------------------------------------------- */

    $('.md-input').find('.md-input-control')
        .each(function() {
            var $parent = $(this).parent();
            if ($(this).val() !== '') $parent.addClass('completed');
        })
        .on('focus', function() {
            var $parent = $(this).parent();
            $parent.addClass('focus');
        })
        .on('blur', function() {

            var $parent = $(this).parent();
            $parent.removeClass('focus');

            if ($(this).val() !== '') $parent.addClass('completed');
            else $parent.removeClass('completed');
        })
        .on('input, change', function() {

            var $parent = $(this).parent();

            if ($(this).val() !== '') $parent.addClass('completed');
            else $parent.removeClass('completed');
        });



    /* -------------------------------------------------------------------------------------------------------------- *
     * Carousel
     * -------------------------------------------------------------------------------------------------------------- */

    /**
     * Default value for count of OWL Carousel thumbnails
     * @type {number}
     */
    var OWL_DEFAULT_THUMBNAIL_ITEMS = 6;

    /**
     * Default value for OWL Carousel autoplay timeout
     * @type {number}
     */
    var OWL_DEFAULT_AUTOPLAY_TIMEOUT = 3000;

    /**
     * Callback function which generates thumbnails for OWL Carousel
     */
    var setThumbs = function() {

        // Carousel element
        var $carousel = this.$element,
            // Items array
            items = this._items;

        // REQUIRED
        if (typeof $carousel === 'undefined' || typeof items === 'undefined') return;

        var cnt_thumbnails = $carousel.data('owl-thumnailitems');
        if (typeof cnt_thumbnails === 'undefined') cnt_thumbnails = OWL_DEFAULT_THUMBNAIL_ITEMS;

        // Create wrapper for thumbnails
        var $thumbs = $('<div>').addClass('owl-thumbs');

        // Append Thumbnails Wrapper
        $carousel.append($thumbs);

        // Set thumbnails for each element (if hash value not empty)
        $.each(items, function() {

            var $img = $(this).find('img'),
                hash = $(this).find('[data-hash]').data('hash');

            // REQUIRED
            if ($img.length === 0 || typeof hash === 'undefined') return;

            // Create & Append thumbnail link
            $thumbs.append(
                $('<a>')
                    .attr('href', '#' + hash)
                    .addClass('owl-thumbnail')

                    .append(
                        $('<img>')
                            .attr('src', $img.attr('src'))
                            .addClass('image')
                    )
            );

        });

        // Initialize OWL Carousel for thumbnails and save in this object
        this.thumbs = $thumbs.owlCarousel({
            dots : false,
            items: cnt_thumbnails
        });


        // Current item index
        var _current = this._current;

        // Change active element in thumbnails OWL Carousel
        this.thumbs.trigger('to.owl.carousel', _current);
        // Add active class to link
        this.thumbs.find('.owl-item').eq(_current).find('.owl-thumbnail').addClass('owl-thumbnail-active');
    };

    var changeActiveThumb = function(event) {

        //
        // don't use this function with loop === true
        //

        // Thumbnails OWL Carousel
        var thumbs = this.thumbs,
            // Active item index
            item_index = event.item.index,
            // Items count
            items_count = event.item.count;

        // REQUIRED
        if (typeof thumbs === 'undefined' || !items_count || item_index === null) return;

        // Trigger Event
        thumbs.trigger('to.owl.carousel', item_index);

        // Remove active class from link
        thumbs.find('.owl-thumbnail-active').removeClass('owl-thumbnail-active');
        // Add active class to new link
        thumbs.find('.owl-item').eq(item_index).find('.owl-thumbnail').addClass('owl-thumbnail-active');

    };

    $('.owl-carousel').each(function() {

        // Default OWL Carousel parameters
        var owl_parameters = {
            items: 1,     // Items count
            dots : false, // Disable dots
            navText: [
                '<i class="icon fa fa-angle-left"></i>',
                '<i class="icon fa fa-angle-right"></i>'
            ],
            URLhashListener: true,
            startPosition: 'URLHash'
        };

        // Carousel element
        var $this = $(this),
            // Carousel items count (opt)
            data_items = $this.data('owl-items'),
            items_count = 1;

        // Count of items
        if (typeof data_items !== 'undefined') items_count = parseInt(data_items, 10);

        // Set to config
        owl_parameters['items'] = items_count;

        // Disable mouse drag
        if ($this.hasClass('owl-no-mousedrag')) owl_parameters['mouseDrag'] = false;
        // Show prev/next navigation
        if ($this.hasClass('owl-navigation')) owl_parameters['nav'] = true;
        // Show dots navigation
        if ($this.hasClass('owl-pagination')) owl_parameters['dots'] = true;

        // Enable autoplay
        if ($this.hasClass('owl-autoplay')) {

            owl_parameters['loop'] = true;
            owl_parameters['autoplay'] = true;

            owl_parameters['autoplayTimeout'] = typeof ($this.data('owl-autoplay-timeout')) !== 'undefined'
                ? $this.data('owl-autoplay-timeout')
                : OWL_DEFAULT_AUTOPLAY_TIMEOUT;
        }

        // Responsive Items Count
        var data_items_responsive = $this.data('owl-items-responsive');
        if (typeof data_items_responsive !== 'undefined') {

            var arr = data_items_responsive.split(';'),
                responsive = {};

            responsive[1000] = { items: items_count };
            responsive[0] = { items: 1 };

            for (var i = 0, j = arr.length; i < j; i++) {

                var _arr = arr[i].split(':');
                if (typeof _arr[0] === 'undefined' || typeof _arr[1] === 'undefined') continue;

                var max_w = parseInt((_arr[0]).trim(), 10),
                    items_cnt = parseInt((_arr[1]).trim(), 10);

                responsive[max_w] = { items: items_cnt }
            }

            owl_parameters['responsive'] = responsive;
            owl_parameters['responsiveClass'] = true;
        }

        // Custom Animation
        var animate_in = $(this).data('owl-animate-in'),
            animate_out = $(this).data('owl-animate-out');

        if (typeof animate_in !== 'undefined') owl_parameters['animateIn'] = animate_in;
        if (typeof animate_out !== 'undefined') owl_parameters['animateOut'] = animate_out;

        // Enable thumbnails
        if ($this.hasClass('owl-thumbnails')) {

            owl_parameters['dots'] = false;
            owl_parameters['startPosition'] = 'URLHash';
            owl_parameters['onInitialized'] = setThumbs;

            owl_parameters['onChanged'] = changeActiveThumb;
        }

        // Initialize OWL Carousel
        $(this).owlCarousel(owl_parameters);
    });



    /* -------------------------------------------------------------------------------------------------------------- *
     * Waves
     * -------------------------------------------------------------------------------------------------------------- */

    $('.btn-waves').each(function() {
        Waves.attach(this, ['waves-light']);
    });

    Waves.init();



    /* -------------------------------------------------------------------------------------------------------------- *
     * Mask opacity from data
     * -------------------------------------------------------------------------------------------------------------- */

    $('[data-mask-opacity]').each(function() {
        var $this = $(this),
            opacity = $this.data('mask-opacity');
        $this.css('opacity', opacity);
    });



    /* -------------------------------------------------------------------------------------------------------------- *
     * PF sticky plugin
     * -------------------------------------------------------------------------------------------------------------- */

    if (!is_mobile) $('.sticky').pfvt_sticky();



    /* -------------------------------------------------------------------------------------------------------------- *
     * Tooltips on hover
     * -------------------------------------------------------------------------------------------------------------- */

    function initTooltips() {
        $('[data-toggle=\'tooltip\']').attr('data-animation', true).tooltip({ container: 'body' });
    }

    // First init
    initTooltips();

    // Makes tooltips work on ajax generated content
    // $(document).ajaxStop(initTooltips);



    /* -------------------------------------------------------------------------------------------------------------- *
     * Popovers
     * -------------------------------------------------------------------------------------------------------------- */

    $('[data-toggle="popover"]').popover();



    /* -------------------------------------------------------------------------------------------------------------- *
     * Animated List
     * -------------------------------------------------------------------------------------------------------------- */

    var LIST_ANIMATED_DELAY      = .375;
    var LIST_ANIMATED_DELAY_STEP = .05;

    $('.list-animated').each(function() {

        var $list = $(this),
            item_delay = parseFloat($list.data('list-delay')),
            item_delay_step = parseFloat($list.data('list-delay-step')),
            list_items = $list.data('list-items');

        if (item_delay === 'undefined' || isNaN(item_delay)) item_delay = LIST_ANIMATED_DELAY;
        if (item_delay_step === 'undefined' || isNaN(item_delay_step)) item_delay_step = LIST_ANIMATED_DELAY_STEP;

        $list.find('.list-animated-item[data-list-name="' + list_items + '"]').each(function(i) {

            var td_val = (item_delay + i * item_delay_step) + 's';

            $(this).css({
                '-webkit-transition-delay': td_val,
                   '-moz-transition-delay': td_val,
                    '-ms-transition-delay': td_val,
                     '-o-transition-delay': td_val,
                        'transition-delay': td_val
            });
        });
    });



    /* -------------------------------------------------------------------------------------------------------------- *
     * Appear
     * -------------------------------------------------------------------------------------------------------------- */

    $('.appear-element').appear();

    $body.on('appear', '.appear-element', function () {
        var $this = $(this);
        if ($this.hasClass('appeared')) return;
        $this.addClass('appeared');
    });



    /* -------------------------------------------------------------------------------------------------------------- *
     * Stellar
     * -------------------------------------------------------------------------------------------------------------- */

    if (!is_mobile) {
        $.stellar({
            responsive: true,
            horizontalOffset: 0,
            verticalOffset: 0,
            horizontalScrolling: false,
            hideDistantElements: false
        });
    }



    /* -------------------------------------------------------------------------------------------------------------- *
     * Malihu CustomScrollbar
     * -------------------------------------------------------------------------------------------------------------- */

    $('.custom-scrollbar').mCustomScrollbar({
        scrollInertia: 150,
        height       : '100%',
        axis         : 'y'
    });



    /* -------------------------------------------------------------------------------------------------------------- *
     * Circle progress
     * -------------------------------------------------------------------------------------------------------------- */

    $('.progress-circle').each(function() {

        var params = {};

        var $progress = $(this),
            progress_value = $progress.data('progress-circle-value');

        // Value - REQUIRED
        if (progress_value === 'undefined') return;

        params.value = progress_value;

        // Contextual color classes
        if ($progress.hasClass('progress-circle-default')) params.fill = { color: hex2RGBA(THEME_COLORS.DEFAULT, 100) };
        if ($progress.hasClass('progress-circle-primary')) params.fill = { color: hex2RGBA(THEME_COLORS.PRIMARY, 100) };
        if ($progress.hasClass('progress-circle-info'))    params.fill = { color: hex2RGBA(THEME_COLORS.INFO   , 100) };
        if ($progress.hasClass('progress-circle-success')) params.fill = { color: hex2RGBA(THEME_COLORS.SUCCESS, 100) };
        if ($progress.hasClass('progress-circle-warning')) params.fill = { color: hex2RGBA(THEME_COLORS.WARNING, 100) };
        if ($progress.hasClass('progress-circle-danger'))  params.fill = { color: hex2RGBA(THEME_COLORS.DANGER , 100) };

        var progress_target = $progress.data('progress-circle-target');
        if (progress_target === 'undefined') return;

        var $target = $(progress_target);
        if ($target.length === 0) return;

        $progress.circleProgress(params).on('circle-animation-progress', function(event, progress, stepValue) {
            $target.html(String(parseInt(stepValue.toFixed(2).substr(1) * 100)) + '%');
        });

    });



    /* -------------------------------------------------------------------------------------------------------------- *
     *
     * DEMO IIFE (demo.js)
     * Note: you can delete this
     *
     * -------------------------------------------------------------------------------------------------------------- */


    /* -------------------------------------------------------------------------------------------------------------- *
     * Modals
     * -------------------------------------------------------------------------------------------------------------- */

    $('#demo-modal-varying').on('show.bs.modal', function (event) {

        var button = $(event.relatedTarget),
            triggered = button.data('triggered'),
            modal = $(this);

        modal.find('[name="demo-var-content-name"]').val(triggered).trigger('change');
    });



    /* -------------------------------------------------------------------------------------------------------------- *
     * Charts
     * -------------------------------------------------------------------------------------------------------------- */

    /*
     * Dashboard "Current week stat" line chart
     * ======================================== */

    var $demo_chart_line_cws = $('#dashboard-01-current-week-stat');
    if ($demo_chart_line_cws.length > 0) {
        new Chart($demo_chart_line_cws, {
            type: 'line',
            data: {
                labels: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'],
                datasets: [{
                    label: ' Current Week Visits',
                    data: [70, 100, 45, 110, 50, 90, 70],
                    backgroundColor: hex2RGBA(THEME_COLORS.PRIMARY, 100),
                    borderColor: hex2RGBA(THEME_COLORS.PRIMARY, 100),
                    borderWidth: 1,
                    pointRadius: 0,
                    pointHitRadius: 5
                }]
            },
            options: {
                maintainAspectRatio: false,
                legend: { display: false },
                elements: {
                    point: {
                        // radius: 0,
                        // hitRadius: 10,
                        // hoverRadius: 10
                    }
                },
                scales: {
                    xAxes: [{
                        display: false,
                        gridLines: {
                            display: false,
                            zeroLineColor: 'transparent',
                            drawBorder: false
                        },
                        ticks: {
                            fontColor: '#fff'
                        }
                    }],
                    yAxes: [{
                        display: false,
                        gridLines: {
                            drawBorder: false
                        },
                        ticks: {
                            beginAtZero: true
                        }
                    }]
                }
            }
        });
    }

    /*
     * Dashboard "CPU usage" doughnut chart
     * ==================================== */
    var $demo_chart_cpu_usage = $('#demo-chart-cpu-usage');
    if ($demo_chart_cpu_usage.length > 0) {
        new Chart($demo_chart_cpu_usage, {
            type: 'doughnut',
            data: {
                labels: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri'],
                datasets: [{
                    label: ' CPU usage',
                    data: [879, 980, 594, 398, 1345],
                    backgroundColor: [
                        hex2RGBA(THEME_COLORS.PRIMARY, 90),
                        hex2RGBA(THEME_COLORS.INFO,    90),
                        hex2RGBA(THEME_COLORS.SUCCESS, 90),
                        hex2RGBA(THEME_COLORS.DANGER,  90),
                        hex2RGBA(THEME_COLORS.DARK,    90)
                    ],
                    borderColor: '#fff',
                    hoverBorderColor: '#fff',
                    borderWidth: 1
                }]
            },
            options: {
                maintainAspectRatio: false,
                legend: {
                    display: false
                }
            }
        });
    }

    /*
     *  Dashboard "Memory usage" line chart
     */

    var $demo_chart_line_memory_usage = $('#demo-chart-line-memory-usage');
    if ($demo_chart_line_memory_usage.length > 0) {
        new Chart($demo_chart_line_memory_usage, {
            type: 'line',
            data: {
                labels: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'],
                datasets: [{
                    label: ' Current Week Visits',
                    data: [879, 980, 594, 398, 1345, 1101, 1469],
                    backgroundColor: hex2RGBA(THEME_COLORS.SECONDARY, 100),
                    borderColor: hex2RGBA(THEME_COLORS.SECONDARY, 100),
                    borderWidth: 3,
                    pointRadius: 3,
                    pointHitRadius: 5,
                    fill: false
                }]
            },
            options: {
                maintainAspectRatio: false,
                legend: { display: false },
                scales: {
                    xAxes: [{ display: false }],
                    yAxes: [{ display: false }]
                }
            }
        });
    }



    /* -------------------------------------------------------------------------------------------------------------- *
     * Charts, documentation page
    /* -------------------------------------------------------------------------------------------------------------- */

    /*
     * Line Chart
     * ========== */

    var $demo_chart_line = $('#demo-chart-line');
    if ($demo_chart_line.length > 0) {
        new Chart($demo_chart_line, {
            type: 'line',
            data: {
                labels: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'],
                datasets: [{
                    label: ' Current Week Visits',
                    data: [879, 980, 594, 398, 1345, 1101, 1469],
                    backgroundColor: hex2RGBA(THEME_COLORS.PRIMARY_LIGHT, 100),
                    borderColor: hex2RGBA(THEME_COLORS.PRIMARY_LIGHT, 100),
                    borderWidth: 3,
                    pointRadius: 3,
                    pointHitRadius: 5,
                    fill: false
                }, {
                    label: ' Last Week Visits',
                    data: [787, 591, 398, 402, 786, 978, 1150],
                    backgroundColor: hex2RGBA(THEME_COLORS.SECONDARY_LIGHT, 100),
                    borderColor: hex2RGBA(THEME_COLORS.SECONDARY_LIGHT, 100),
                    borderWidth: 3,
                    pointRadius: 3,
                    pointHitRadius: 5,
                    fill: false
                }]
            },
            options: {
                legend: { display: false },
                scales: {
                    xAxes: [{
                        gridLines: {
                            zeroLineColor: 'transparent'
                        }
                    }],
                    yAxes: [{
                        gridLines: {
                            drawTicks: false,
                            display: false
                        },
                        ticks: {
                            beginAtZero: true
                        }
                    }]
                }
            }
        });
    }

    /*
     * Bar Chart
     * ========= */

    var $demo_chart_bar = $('#demo-chart-bar');
    if ($demo_chart_bar.length > 0) {
        new Chart($demo_chart_bar, {
            type: 'bar',
            data: {
                labels: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'],
                datasets: [{
                    label: ' Current Week Visits',
                    data: [879, 980, 594, 398, 1345, 1101, 1469],
                    backgroundColor: [
                        hex2RGBA(THEME_COLORS.PRIMARY, 100),
                        hex2RGBA(THEME_COLORS.INFO, 100),
                        hex2RGBA(THEME_COLORS.SUCCESS, 100),
                        hex2RGBA(THEME_COLORS.WARNING, 100),
                        hex2RGBA(THEME_COLORS.DARK, 100),
                        hex2RGBA(THEME_COLORS.DANGER, 100),
                        hex2RGBA(THEME_COLORS.PRIMARY, 100)
                    ],
                    borderColor: [
                        hex2RGBA(THEME_COLORS.PRIMARY, 100),
                        hex2RGBA(THEME_COLORS.INFO, 100),
                        hex2RGBA(THEME_COLORS.SUCCESS, 100),
                        hex2RGBA(THEME_COLORS.WARNING, 100),
                        hex2RGBA(THEME_COLORS.DARK, 100),
                        hex2RGBA(THEME_COLORS.DANGER, 100),
                        hex2RGBA(THEME_COLORS.PRIMARY, 100)
                    ],
                    borderWidth: 0
                }]
            },
            options: {
                legend: { display: false },
                scales: {
                    yAxes: [{ ticks: { beginAtZero:true } }]
                }
            }
        });
    }

    /*
     * Radar Chart
     * =========== */

    var $demo_chart_radar = $('#demo-chart-radar');
    if ($demo_chart_radar.length > 0) {
        new Chart($demo_chart_radar, {
            type: 'radar',
            data: {
                labels: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'],
                datasets: [
                    {

                        label: ' Current Week Visits',
                        backgroundColor: hex2RGBA(THEME_COLORS.SECONDARY, 50),

                        borderWidth: 1,
                        borderColor: hex2RGBA(THEME_COLORS.SECONDARY, 70),

                        pointBackgroundColor: hex2RGBA(THEME_COLORS.SECONDARY, 70),
                        pointBorderColor: '#fff',
                        pointHoverBackgroundColor: '#fff',
                        pointHoverBorderColor: hex2RGBA(THEME_COLORS.SECONDARY, 70),

                        data: [879, 891, 1054, 398, 1345, 1101, 1469]
                    },
                    {

                        label: ' Last Week Visits',
                        backgroundColor: hex2RGBA(THEME_COLORS.DARK, 50),

                        borderWidth: 1,
                        borderColor: hex2RGBA(THEME_COLORS.DARK, 70),

                        pointBackgroundColor: hex2RGBA(THEME_COLORS.DARK, 70),
                        pointBorderColor: '#fff',
                        pointHoverBackgroundColor: '#fff',
                        pointHoverBorderColor: hex2RGBA(THEME_COLORS.DARK, 70),

                        data: [1500, 891, 398, 1000, 786, 978, 1150]
                    }
                ]
            },
            options: {
                legend: { display: false },
                scales: {
                    yAxes: [{
                        display: false,
                        ticks: { beginAtZero: true }
                    }]
                }
            }
        });
    }

    /*
     * Polar Area Chart
     * ================ */

    var $demo_chart_polar_area_preview = $('#demo-chart-polar-area-preview');
    if ($demo_chart_polar_area_preview.length > 0) {
        new Chart($demo_chart_polar_area_preview, {
            type: 'polarArea',
            data: {
                labels: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'],
                datasets: [{
                    label: ' Current Week Visits',
                    data: [879, 980, 594, 398, 1345, 1101],
                    backgroundColor: [
                        hex2RGBA(THEME_COLORS.PRIMARY, 100),
                        hex2RGBA(THEME_COLORS.INFO, 100),
                        hex2RGBA(THEME_COLORS.SUCCESS, 100),
                        hex2RGBA(THEME_COLORS.WARNING, 100),
                        hex2RGBA(THEME_COLORS.DANGER, 100),
                        hex2RGBA(THEME_COLORS.DARK, 100)
                    ],
                    borderColor: '#fff',
                    hoverBorderColor: '#fff',
                    borderWidth: 1,
                    highlight: "#A8B3C5"
                }]
            },
            options: {
                legend: { display: false },
                scales: {
                    yAxes: [{ ticks: { beginAtZero: true } }]
                }
            }
        });
    }

    var $demo_chart_polar_area = $('#demo-chart-polar-area');
    if ($demo_chart_polar_area.length > 0) {
        new Chart($demo_chart_polar_area, {
            type: 'polarArea',
            data: {
                labels: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'],
                datasets: [{
                    label: ' Current Week Visits',
                    data: [879, 980, 594, 398, 1345, 1101],
                    backgroundColor: [
                        hex2RGBA(THEME_COLORS.PRIMARY, 100),
                        hex2RGBA(THEME_COLORS.INFO, 100),
                        hex2RGBA(THEME_COLORS.SUCCESS, 100),
                        hex2RGBA(THEME_COLORS.WARNING, 100),
                        hex2RGBA(THEME_COLORS.DANGER, 100),
                        hex2RGBA(THEME_COLORS.DARK, 100)
                    ],
                    borderColor: '#fff',
                    hoverBorderColor: '#fff',
                    borderWidth: 1,
                    highlight: "#A8B3C5"
                }]
            },
            options: {
                legend: { display: false },
                scales: {
                    yAxes: [{ ticks: { beginAtZero: true } }]
                }
            }
        });
    }

    /*
     * Pie Chart
     * ========= */

    var $demo_chart_pie = $('#demo-chart-pie');
    if ($demo_chart_pie.length > 0) {
        new Chart($demo_chart_pie, {
            type: 'pie',
            data: {
                labels: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri'],
                datasets: [{
                    label: ' Current Week Visits',
                    data: [879, 980, 594, 398, 1345],
                    backgroundColor: [
                        hex2RGBA(THEME_COLORS.PRIMARY, 100),
                        hex2RGBA(THEME_COLORS.INFO, 100),
                        hex2RGBA(THEME_COLORS.SUCCESS, 100),
                        hex2RGBA(THEME_COLORS.DANGER, 100),
                        hex2RGBA(THEME_COLORS.DARK,100)
                    ],
                    borderColor: '#fff',
                    hoverBorderColor: '#fff',
                    borderWidth: 1
                }]
            },
            options: {
                legend: {
                    display: false
                },
                title: {
                    display : true,
                    text    : 'Pie chart',
                    fontSize: 14,
                    color   : '#555'
                }
            }
        });
    }

    /*
     * Doughnut Chart
     * ============== */

    var $demo_chart_doughnut = $('#demo-chart-doughnut');
    if ($demo_chart_doughnut.length > 0) {
        new Chart($demo_chart_doughnut, {
            type: 'doughnut',
            data: {
                labels: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri'],
                datasets: [{
                    label: ' Current Week Visits',
                    data: [879, 980, 594, 398, 1345],
                    backgroundColor: [
                        hex2RGBA(THEME_COLORS.PRIMARY, 100),
                        hex2RGBA(THEME_COLORS.INFO, 100),
                        hex2RGBA(THEME_COLORS.SUCCESS, 100),
                        hex2RGBA(THEME_COLORS.DANGER, 100),
                        hex2RGBA(THEME_COLORS.DARK, 100)
                    ],
                    borderColor: '#fff',
                    hoverBorderColor: '#fff',
                    borderWidth: 1
                }]
            },
            options: {
                legend: {
                    display: false
                },
                title: {
                    display : true,
                    text    : 'Doughnut chart',
                    fontSize: 14,
                    color   : '#555'
                }
            }
        });
    }

});



/* -------------------------------------------------------------------------------------------------------------- *
 * Finish loading
 * -------------------------------------------------------------------------------------------------------------- */

$(window).on('load', function() {

    $('body').addClass('loaded');

    setTimeout(function() {
        $('.preloader').fadeOut('slow');
    }, 300);

});

