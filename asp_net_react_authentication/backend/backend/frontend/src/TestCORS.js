import { useState, useEffect } from "react";

const apiBase = "https://localhost:7129/api/User";

export default function TestCORS() {
    const [data, setData] = useState();

    useEffect(() => {
        // fetch data        
          fetch(apiBase, {
                method: "GET",
                mode: "cors"
            })
            .then(response => response.json())
            .then(result => result.map(user => {return (<p>{user.userName}</p>)}))
            .then(result => setData(result));
        ;
      }, []);

    return (
        <div>
            <p>User list:</p>
             {data}
        </div>
    );
};