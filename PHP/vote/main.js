$(document).ready(function()
{
	$('.toggler').on('click', function()
	{
		var clickedElem = $(this);
		var cardBody = undefined;
		if (clickedElem.hasClass('card-header'))
		{
			cardBody = clickedElem.parent().find('.card-body');
		}
		else
		{
			cardBody = clickedElem.parent();
		}
		cardBody = $(cardBody);

		$('.card-body').each(function()
		{
			var elem = $(this);
			if (cardBody.is(elem))
			{
				if (!clickedElem.hasClass('toggler-header'))
				{
					elem.addClass('collapse');
					var nextElem = elem.parent().next().find('.card-body');
					nextElem.removeClass('collapse');	
					nextElem.addClass('next-elem');
				}
				else
				{
					elem.removeClass('collapse');
				}
			}
			else
			{
				if (elem.hasClass('next-elem'))
				{
					elem.removeClass('next-elem');
				}
				else
				{
					elem.addClass('collapse');				
				}
			}
		})
	});
});