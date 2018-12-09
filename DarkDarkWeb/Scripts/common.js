$(function(){
    $(".resource-search--more .arrow").on('click', function(e){
        $(e.currentTarget).parent().parent().find('.resource-search--details').slideToggle(300);
        $(e.currentTarget).toggleClass("open");
    });
});