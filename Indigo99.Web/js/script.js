jQuery(document).ready(function() {
	jQuery("input").each(function() {
		jQuery(this).data('holder',jQuery(this).attr('placeholder'));

			jQuery(this).focusin(function(){
    			jQuery(this).attr('placeholder','');
			});
			
			jQuery(this).focusout(function(){
    			jQuery(this).attr('placeholder',jQuery(this).data('holder'));
			});
	});
});


$(window).load(function() {
  $("#isliders").flexisel({
    visibleItems: 3.25,
    setMaxWidthAndHeight : true,
    maxWidth: 850,
    maxHeight: 450,
    animationSpeed: 2000,
    autoPlay: true,
    autoPlaySpeed: 2000,
    pauseOnHover: true,
    clone: true,
    enableResponsiveBreakpoints: true,
    responsiveBreakpoints: {
      portrait: {
        changePoint:1200,
        visibleItems: 3.25
      },
      portrait: {  
        changePoint:485,
        visibleItems: 1.84
      },
      portrait: {  
        changePoint:372,
        visibleItems: 1.37
      },  
      portrait: {  
        changePoint:420,
        visibleItems: 1.38  // or 1.32
      }, 
      portrait: {  
        changePoint:318,
        visibleItems: 1.18  // 324; 1.18
      },  
      landscape: {
        changePoint:1026,
        visibleItems: 2.15
      }, 
      tablet: {
        changePoint:804,
        visibleItems: 3.45
      },
      tablet: {
        changePoint:768,
        visibleItems: 2.15
      }
    }
  });
});
