getHashNodeInterop = {};

const query = `
{
  user(username: "codetopg") {
    publication {
      posts(page: 0) {
       slug
       title
       brief
       coverImage
       contentMarkdown
       dateUpdated
      }
    }
  }
}`;

getHashNodeInterop.getData = async function gql() {
    const response = await fetch("https://api.hashnode.com", {
        method: "post",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({ query })
    });
    const body = await response.json();
    console.log(body);
    return body;
    
}
