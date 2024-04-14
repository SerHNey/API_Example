import logo from './logo.svg';
import './App.css';
import { Component  } from 'react';

class App extends Component {
  constructor() {
    super();
    this.state = {
      users: []
    }
  }

  getUsers = async () => {
    var response = await fetch(
      "api/users",
      {
        method: 'get'
      }
    )

    var responsejson = await response.json();
    this.setState({
      users: responsejson
    })
  }

  render() {
    const users = this.state.users.map((item, index) => <li key={index}>{item.sqehg}</li>)

    return (
      <div className='App'>
        <button onClick={this.getUsers}>Загрузить список пользователей2</button>
        <ul>{users}</ul>
      </div>
    );
  }
}

export default App;
