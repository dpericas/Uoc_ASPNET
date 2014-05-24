$(document).ready(function(){ // Quan el document està ready, s' executa tot el jquery necessari.
	eventControl();
	contentBuilder(1);
});
// COMENÇA FUNCIÓ GESTOR D' EVENTS ------------------------------------------//
function eventControl(){ // Controlem els Events;
	stopEvents(); // Parem els events anteriorment activats perque no se'ns dupliquin.
	console.log("Reloading Events");
	$('.treservas').hover(
		function(){
			$(this).css('backgroundColor', 'grey');
			$(this).css('color', 'white');
		},
		function(){
			$(this).css('backgroundColor', '#D8D8D8');
			$(this).css('color', 'black');
		}
	);
	$('.novamodif').click(function(){
		//idToEdit="new";
		if ( $(this).attr('id') == "novaReservaForm" ) resAction="addNew";
		else {
			resAction="editRes";
			idToEdit=($(this).attr('id')).split('id')[1];;
		}
		contentBuilder(2);
	});
	$('.detailres').click(function(){
		resAction="detailRes"
		idToEdit=($(this).attr('id')).split('id')[1];
		contentBuilder(4);
	});
	$('.delRes').click(function(){
		resAction="deleteRes"
		idToEdit=($(this).attr('id')).split('id')[1];
		searchReserves(resAction,idToEdit);
	});
	$('.menuClass').hover(function(){
			$(this).css('color', 'grey');
		},
		function(){
			$(this).css('color', 'white');
		});
	$('#showList').click(function(){
		contentBuilder(1);
	});
	$('.show24h').click(function(){
		contentBuilder(3);
	});
	
	$('#reservaForm').submit(function(){
		$('#infoBox').text(''); // Buidem el text, d'errors anteriors.
		console.log('submiting formulary');
		formFull=true;
		$('.fieldsVal').each(function(){ // Comprovem que als camps de introducció de dades hi hagi value.
			fieldFull=true;
			if ($.trim($(this).val()).length == 0 && $(this).attr('name') != "divTime" && $(this).attr('name') != "newComent"){
				$(this).addClass("failMark");
				fieldFull = false;
				formFull=false;
				$('#infoBox').append('<h3>ALERT. Falten dades al camp obligatori: '+$('label[for="'+$(this).attr('name')+'"]').text().replace(':','')+'</h3>');
			}
			else if (fieldFull) {
				if ( $(this).attr('name') == "newComensal" ) { // validem el camp comensals.
					if ( ! $.isNumeric($(this).val()) ) {
						$('#infoBox').append('<h3>ALERT. Camp Comensals ha de ser en format numeric.</h3>');
						$(this).addClass("failMark");
						formFull=false;
					}
					else if ( $(this).val() > 10 || $(this).val() < 1) {
						$('#infoBox').append('<h3>ALERT. Nomes s\'accepten reserves de un minim de 1 comensal fins a un maxim de 10.</h3>');
						$(this).addClass("failMark");
						formFull=false;
					}
					else $(this).removeClass("failMark");
				}
				else if ( $(this).attr('name') == "newTelf" ) { // validem el camp telefon.
					if ( ! $.isNumeric($(this).val()) ) {
						$('#infoBox').append('<h3>ALERT. Camp Telefon ha de ser en format numeric.</h3>');
						$(this).addClass("failMark");
						formFull=false;
					}
					else $(this).removeClass("failMark");
				}
				else if ( $(this).attr('name') == "divTime" ) { // Validem que la reserva sigui posterior a les 24 hores.
					if ( $('#idForm').length > 0 ) dema=($.now()+parseInt(1*60*60*1000)); //permetem modificar les reserves fins a 1 hora abans, ja que podriem haver de modificar reserves del mateix dia.
					else dema=($.now()+parseInt(24*60*60*1000)); //Per noves reserves, no permetem reserves abans de 24h.
					timeReserva=new Date($('#anys').val(),($('#mesos').val()-1),$('#dies').val(),$('#hores').val(),$('#minuts').val()).getTime();
					if ( dema > timeReserva ) {
						$('.fieldTime').addClass("failMark");
						if ( $('#idForm').length > 0 ) $('#infoBox').append('<h3>ALERT. No es pot modificar una reserva per abans de 1 hora. Procediu a eliminar.</h3>');
						else $('#infoBox').append('<h3>ALERT. La hora de la reserva ha de ser posterior a les 24h.</h3>');
						formFull=false;
					}
					else $('.fieldTime').removeClass("failMark");
				}
				else $(this).removeClass("failMark"); // si no es un camp a validar, com que ja esta en estat fieldFull podem treure el error.
			}
		});
		if (formFull){
			postData = $(this).serialize();
			if ( $('#idForm').length != 0 ) searchReserves("updatePost",0,postData);
			else searchReserves("sendPost",0,postData);
		}
		return false; //Evitem que s' executi el submit i no recarregui la pàgina.
	});	
}

function stopEvents(){  // Funció per parar els events cada cop qeu es crea un nou element i em d' activar el gestor d' events.
	$('.treservas').off('hover');
	$('.novamodif').off('click');
	$('.detailres').off('click');
	$('.delRes').off('click');
	$('.menuClass').off('hover');
	$('#showList').off('click');
	$('#show24h').off('click');
	$('#reservaForm').off('submit');
}
// FINALITZA FUNCIÓ GESTOR D' EVENTS ------------------------------------------------//

function contentBuilder(page){ //Construïm el contingut segons l' opció.
	$page=page;
	if ( typeof(lookfor24h) != "undefined" ) clearInterval(lookfor24h); //abans de construïr res, parem la cerca de reserves de les últimes 24h.
	switch (page){
		case 1:{
			lookfor24h=setInterval('searchReserves("24hcheck")',60000); //Només cerquem les reserves de les últimes 24h, en el únic cas del llistat general.
			$('#titleh').text('Llistat de Reserves.');
			searchReserves();
			searchReserves("24hcheck"); //primera cerca per tal de mostrar d'entrada el link si ha d'existir. Després posem el setinterval cada 60 segons.
			break;
		} 
		case 2:{
			if ( resAction == "addNew" ) {$('#titleh').text('Nova Reserva.');searchReserves(resAction,"new");}
			else {$('#titleh').text('Modifica Reserva Num.'+idToEdit);searchReserves(resAction,idToEdit);}
			break;
		}
		case 3:{
			$('#titleh').text('Llistat de Reserves de les Proximes 24h.');
			searchReserves("24h");
			break;
		}
		case 4:{
			$('#titleh').text('Reserva Num. '+idToEdit);
			searchReserves(resAction,idToEdit);
			break;
		}
	}
	listMenuBuilder();
}

function searchReserves(valAction,idData,postData){  //Funció del motor Ajax, que utilitza getreservas.php
	if ( postData == undefined ) postData={};
	if ( idData != undefined ) postData=postData+'&id='+idData;
	if ( valAction != undefined ) postData=postData+'&actionDb='+valAction;
	$.ajax({
		url: 'getReservas.php',
		data : postData,
		type:'GET',
		dataType: 'html',
		success:function(htmlresp){
			console.log('Consulta Success');
			if ( valAction == "deleteRes" ) {
				if ( $page != 4 ){
					$('#delid'+idData).parent().parent().parent().remove();
					if($('#tableReservas tr').length == 0) { // Comprovem que després d' eliminar quedin linees a la taula, en cas contrari fem una consulta del llistat per mostrar que no hi ha reserves disponibles.
						if ( $page == 1 ) searchReserves();
						else searchReserves("24h");
					}
				}
				else contentBuilder(1); // En el cas de que eliminem la reserva desde detall, tornem al llistat principal.
			}
			else if ( valAction == "24hcheck" ) {$('#if24h').html(htmlresp);listMenuBuilder();}
			else {
			if ( valAction == "sendPost" || valAction == "updatePost") {
				if ( htmlresp == "sent" ) contentBuilder(2); //Si estem enviant nova reserva permetem introduir mes reserves.
				else if ( htmlresp == "updated" ) contentBuilder(1); //Si em actualitzat tornem a llistat.
			}
			else $('#UpdatableDiv').html(htmlresp);
			}
			eventControl();
		},
		error:function(){
			console.log('Consulta fail');
		},
		complete:function(){
			console.log('Consulta realitzada');
		}
	});
}

function listMenuBuilder(){  //Creem el menu de llistat segons opcions disponibles.
	$menulist=$('<ul><li><a href="#" id="showList" class="menuClass">LLISTAT</a></li><li><a href="#" class="show24h menuClass">24h</a></li></ul>');
	$('#NavButtonDiv').html($menulist);
	if ( $('#24hlink').length > 0 && ( $page != 3 ) ) $('.show24h').show();
	else $('.show24h').hide();
	if ( $page == 1 ) $('#showList').hide();
	else $('#showList').show();
}