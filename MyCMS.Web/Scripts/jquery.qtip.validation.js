/* incluir este script en una vista junto con qTip para que los errores de 
validación se muestren englobitos "monos" */

$(function () {
    // Run this function for all validation error messages
    $('.field-validation-error').each(function () {
        // Get the name of the element the error message is intended for
        // Note: ASP.NET MVC replaces the '[', ']', and '.' characters with an
        // underscore but the data-valmsg-for value will have the original characters
        var inputElem = '#' + $(this).attr('data-valmsg-for').replace('.', '_').replace('[', '_').replace(']', '_');

        var corners = ['left center', 'right center'];
        var flipIt = $(inputElem).parents('span.right').length > 0;

        // Hide the default validation error
        $(this).hide();

        // Show the validation error using qTip
        $(inputElem).filter(':not(.valid)').qtip({
            content: { text: $(this).text() }, // Set the content to be the error message
            position: {
                my: /*corners[flipIt ? 0 : 1]*/'left center',
                at: /*corners[flipIt ? 1 : 0]*/'right center',
                viewport: $(window)
            },
            border: {
                width: 3,
                radius: 8
            },
            show: { ready: true },
            hide: false,
            style: { classes: 'ui-tooltip-red' }
        });
    });
});    
