// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Close modal
function CloseModal() {
	$( '.modal' ).toggle();
	$( '#modalDiv' ).find( '.modal' ).remove();
};

//Show modal
function ShowModal( data ) {
	if ( data.includes('DOCTYPE') == true ) {
		$( 'html' ).html( data );
	} else {
		$( '#modalDiv' ).html( data );
		$( '.modal' ).toggle();
	}
};

function GetModal(method, controller, action, id ) {
	$.ajax( {
		url: '/' + controller + '/' + action + '/',
		type: method,
		data: { id: id },
		beforeSend: function () {
			document.body.style.cursor = 'wait';
		},
		success: function ( data, textStatus, jqXHR ) {
			ShowResponse( data, textStatus, jqXHR );
		},
		error: function ( jqXHR, textStatus, errorThrown ) {
			ShowResponse( errorThrown, textStatus, jqXHR );
		},
		complete: function ( xhr, textStatus ) {
			document.body.style.cursor = 'auto';
		}
	} );
};

function Submit( controller, action ) {
	$.ajax( {
		url: '/' + controller + '/' + action + '/',
		type: 'POST',
		data: $( '#' + controller + action ).serialize(),
		beforeSend: function () {
			document.body.style.cursor = 'wait';
		},
		success: function ( data, textStatus, jqXHR ) {
			ShowResponse( data, textStatus, jqXHR );
		},
		error: function ( jqXHR, textStatus, errorThrown ) {
			ShowResponse( null, textStatus, jqXHR );
		},
		complete: function ( xhr, textStatus ) {
			document.body.style.cursor = 'auto';
		}
	} );
};

function ShowResponse( data, textStatus, jqXHR ) {
	switch ( jqXHR.status ) {
		case 200:
			ShowModal( data );
			break;
		case 400:
		case 404:
			window.location.href = jqXHR.responseJSON;
			break;
		default:
			ShowModal( data );
			//alert( jqXHR.statusCode )
			break;
	};
}