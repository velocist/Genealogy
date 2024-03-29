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
	$( '#modalDiv' ).html( data );
	$( '.modal' ).toggle();
};

function ShowError( code ) {
	var error = code;
	$.ajax( {
		url: 'Home/Error/',
		type: 'GET',
		data: { xhr: code },
		beforeSend: function () {
			document.body.style.cursor = 'wait';
		},
		success: function ( data, textStatus ) {
			ShowModal( data );
		},
		error: function ( xhr, textStatus ) {
			ShowError( xhr );
		},
		complete: function ( xhr, textStatus ) {
			document.body.style.cursor = 'auto';
		}
	} );
};

//Get modal
function GetModal( controller, action, id ) {
	if ( id == null ) {
		$.ajax( {
			url: '/' + controller + '/' + action + '/',
			type: 'GET',
			beforeSend: function () {
				document.body.style.cursor = 'wait';
			},
			success: function ( data, textStatus ) {
				ShowModal( data );
			},
			error: function ( xhr, textStatus ) {
				ShowModal( xhr );
			},
			complete: function ( xhr, textStatus ) {
				document.body.style.cursor = 'auto';
			}
		} );
	} else {
		$.ajax( {
			url: '/' + controller + '/' + action + '/',
			type: 'GET',
			data: { id: id },
			beforeSend: function () {
				document.body.style.cursor = 'wait';
			},
			success: function ( data, textStatus ) {
				ShowModal( data );
			},
			error: function ( xhr, textStatus ) {
				ShowError( xhr );
			},
			complete: function ( xhr, textStatus ) {
				document.body.style.cursor = 'auto';
			}
		} );
	}
}

function GetModalPost( controller, action, id ) {
	$.ajax( {
		url: '/' + controller + '/' + action + '/',
		type: 'POST',
		data: { id: id },
		beforeSend: function () {
			document.body.style.cursor = 'wait';
		},
		success: function ( data, textStatus ) {
			window.location.reload();
		},
		error: function ( xhr, textStatus ) {
			ShowModal( xhr.responseJSON );
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
		data: $( '#' + action + '' ).serialize(),
		beforeSend: function () {
			document.body.style.cursor = 'wait';
		},
		success: function ( data, textStatus ) {
			window.location.reload();
		},
		error: function ( xhr, textStatus ) {
			ShowModal( xhr.responseJSON );
		},
		complete: function ( xhr, textStatus ) {
			document.body.style.cursor = 'auto';
		}
	} );
};