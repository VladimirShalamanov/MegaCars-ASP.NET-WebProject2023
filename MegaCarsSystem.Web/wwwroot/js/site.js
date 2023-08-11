function menuHamburger() {
    const menuToggle = $('.toggle');
    const showcase = $('.showcase');
    const menuItems = $('.menu');

    menuToggle.toggleClass('active');
    showcase.toggleClass('active');
    menuItems.toggleClass('active');
}


function statistics() {
    $('#statistics_btn').on('click', function (e) {

        e.preventDefault();
        e.stopPropagation();

        if ($('#statistics_box').hasClass('d-none')) {
            $.get('https://localhost:7284/api/statistics', function (data) {
                $('#total_cars').text(data.totalCars + " Cars");
                $('#total_rents').text(data.totalRents + " Rents");

                $('#statistics_box').removeClass('d-none');
                $('#statistics_btn').text('Hide Statistics');
                $('#statistics_btn').removeClass('btn-primary');
                $('#statistics_btn').addClass('btn-danger');
            })
        }
        else {
            $('#statistics_box').addClass('d-none');
            $('#statistics_btn').text('Show Statistics');
            $('#statistics_btn').removeClass('btn-danger');
            $('#statistics_btn').addClass('btn-primary');
        }
    });
}