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
