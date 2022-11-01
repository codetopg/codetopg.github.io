getHashNodeInterop = {};

getHashNodeInterop.getData = async function gql(query) {
    const response = await fetch("https://api.hashnode.com", {
        method: "post",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({ query })
    });
    const body = await response.json();
    //console.log("query from .net" + query)

    //console.log(body);
    return body;
}

getHashNodeInterop.focusToTop = function () {
    document.body.scrollTop = 0; // For Safari
    document.documentElement.scrollTop = 0; // For Chrome, Firefox, IE and Opera
}
