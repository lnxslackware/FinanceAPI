var Connection = (function ($, undefined) {
    var makeHttpRequest = function (data, type, url, headers, success, error) {
        $.ajax({
            url: url,
            type: type,
            success: success,
            error: error,
            headers: headers,
            contentType: 'application/json',
            timeout: 5000,
            data: JSON.stringify(data)
        });
    };

    var getJSON = function (url, headers, success, error) {
        makeHttpRequest({}, "GET", url, headers, success, error);
    };

    var postJSON = function (data, url, headers, success, error) {
        makeHttpRequest(data, "POST", url, headers, success, error);
    };

    var deleteJSON = function (url, success, error) {
        makeHttpRequest({_method: 'delete'}, "POST", url, null, success, error);
    };

    return {
        getJSON: getJSON,
        postJSON: postJSON,
        deleteJSON: deleteJSON
    };
})(jQuery);