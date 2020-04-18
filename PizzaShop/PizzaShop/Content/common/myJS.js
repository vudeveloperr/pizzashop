//sticky:khi scroll menu đóng cứng
$(document).ready(function () {
	//sticky 
	$('.story-area').waypoint(function (direction) {
		if( direction == "down"){
			$('header').addClass('sticky');
		}
		else {
			$('header').removeClass('sticky');
		}
		},{
			offset:'100px'
		}
		)
	}
);

//click product in cart
$(document).on('click','.btn-addToCart',function(e){
	e.preventDefault();//loai bo all event
	if( $(this).hasClass('disable')){
		return false;
	}
	$(document).find('.btn-addToCart').addClass('disable');
	var self = $(this);

	var parent = $(this).parents('.main-item');
	var cardShop = $(document).find('#card-shop');
	var SRC = parent.find('img').attr('src');
	// lay vi tri
	var parentTop = parent.offset().top;
	var parentLeft = parent.offset().left;


	$('<img />', { 
		class: 'img-product-fly',
		src: SRC
	  }).appendTo('body').css({
		  'top'	:	parentTop,
		  'left':	parseInt(parentLeft) + parseInt(parent.width())
	  });

	setTimeout(function(){
		$(document).find('.img-product-fly').css({
			'top'	:	cardShop.offset().top + 40,
		 	'left'	:	cardShop.offset().left + 40
		});
		setTimeout(function() {
			$(document).find('.img-product-fly').remove();
			var cItem = parseInt(cardShop.find('.count-item').data('count')) + 1;
			cardShop.find('.count-item').text(cItem).data('count', cItem);
			$(document).find('.btn-addToCart').removeClass('disable');
		}, 1500);

	  },500);
});