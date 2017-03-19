$(document).ready(function()
{(function($) {
    $.Load = function(selector, url, callback){ $(document.body).Load(selector, url, callback, true); };
    $.fn.Load = function(selector, url, callback, without_selector_document){
        var selector_document = this;
        var e = $('<iframe style="display:none" src="'+url+'"></iframe>');
        $(document.body).append( e );
        $(e).load(function(){
            var x = $(selector, e[0].contentWindow.document);
            if(callback){
                callback(x);
            }else if(without_selector_document != true){
                $(selector_document).html( $(x).html() );
            }
        });
    };
})(jQuery);
});