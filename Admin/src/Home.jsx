import React, { useEffect } from 'react'

function Home() {
    const [data, setData] = React.useState(new Date());
    useEffect(() => {
        const interval = setInterval(() => {
            setData(new Date());
        }, 1000);
        return () => clearInterval(interval);
    },[])

    const [state, setState] = React.useState(0);
    const clickGame = () => {
        
        const click = state + 1;
        setState(click);
        if(click %15 === 0) {
            alert("FizzBuzz");
        }
        else if(click % 5 === 0) {
            alert("Buzz");
        }
        else if(click % 3 === 0) {
            alert("Fizz");
        }    
    }

    useEffect(() => {
        console.log("clickGame", state);
    }, [state])
    
  return (
    <div>
        <h1>Welcome to the Admin Panel</h1>
        <h2>{data.toLocaleTimeString()}</h2>
        <button onClick={() => clickGame()}>click me</button>
    </div>
  )
}

export default Home