import {Component} from 'react';
import { Route, Link, NavLink, Redirect, Switch } from 'react-router-dom';

import * as postService from './services/postService';

import style from './App.module.css';
import Header from './components/Header';
import Main from './components/Main';
import Menu from './components/Menu';
import About from './components/About/Abount';
import ContactUs from './components/ContactUs/ContactUs';

// function App() {
//   return (
//     <div className={style.app}>
//         <div >
//             <Header/> 
//             <div className={style.container}>
//               <Menu/>
//               <Main />
//             </div>     
//         </div>
//     </div>
//   );
// }

class App extends Component {
  constructor(props){
    super(props);
    this.state = {
      posts:[],
      selectedPost: null
    }

    this.onMenuItemCick = this.onMenuItemCick.bind(this);
  }

  componentDidMount() {
    postService.getAll()
      .then(posts => {
        this.setState({posts})
    })
  }

  onMenuItemCick(id){
    this.setState({selectedPost: id})
  }

  getPosts(){
    if (!this.state.selectedPost){
      return this.state.posts;
    } else {
      return [this.state.posts.find(x => x.id == this.state.selectedPost)];
    }
  }

  render() {
    return(
      <div className={style.app}>
        <div >
            <Header/> 
            <div className={style.container}>
                <Menu onMenuItemCick={this.onMenuItemCick} />
                <Switch>
                    <Route path="/" exact>
                        <Main posts={this.getPosts()} />
                    </Route>
                    <Route path="/about" component={About}/>
                    <Route path="/contact-us" render={ContactUs}/>
                    <Route render={(props) => <h1 className="main-wrapper">Default page. Without path</h1>}/>                    
                </Switch>
            </div>     
        </div>
    </div>
    );
  }
}

export default App;
