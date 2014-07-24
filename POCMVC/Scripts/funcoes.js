$(document).ready(function () {
    $(".jsData").mask("99/99/9999");
    $(".jsTelefone").mask("(99)9999-9999");
    $(".jsCPF").mask("999.999.999-99");
    $(".jsCEP").mask("99999-999");
    $(".jsCNPJ").mask("99.999.999/9999-99");
    $(".jsDecimal").maskMoney({ symbol: "", decimal: ",", thousands: "" });
    $('.jsInteiro').keypress(function (evt) {
        evt = (evt) ? evt : window.event
        var charCode = (evt.which) ? evt.which : evt.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57)) {
            status = "This field accepts numbers only."
            return false
        }
        status = ""
        return true
    });
    $('.jsRequired').change(function () {
        if ($(this).val() == "") {
            $('[id="span' + $(this).attr("id") + '"]').remove();
            $('<span class="spRequired" id="span' + $(this).attr("id") + '"> *</span>').insertAfter(this);
        }
        else {
            $('[id="span' + $(this).attr("id") + '"]').remove();
        }
    });
    
    $('#Processando').dialog({
		autoOpen: false,
		width: 600,
		draggable: false,
		resizable: false,
		width: 260,
		height:120,
	});
	$('#menu a, .jsProcessando').click(function(){
		OpenProcessando();
	});

    $(':submit').click(function () {
        var isValid = true;
        isValid = ValidaFormRequired();

        if(isValid)
            OpenProcessando();

        return isValid;
    });
});

function ValidaFormRequired() {
    var isValid = true;
    $.each($('.jsRequired'), function (index, value) {
        if ($(this).val() == "") {
            isValid = false;
            $('[id="span' + $(this).attr("id") + '"]').remove();
            $('<span class="spRequired" id="span' + $(this).attr("id") + '"> *</span>').insertAfter(this);
        }
        else {
            $('[id="span' + $(this).attr("id") + '"]').remove();
        }
    });
    return isValid;
}

function OpenProcessando()
{
    $('<div class="ui-overlay"><div class="ui-widget-overlay"></div></div>').insertAfter('body');
	$('#Processando').dialog('open');
}