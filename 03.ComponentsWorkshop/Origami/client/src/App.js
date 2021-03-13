import {Component} from 'react';

import * as postService from './services/postService';

import style from './App.module.css';
import Header from './components/Header';
import Main from './components/Main';
import Menu from './components/Menu';

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
              <Menu
                onMenuItemCick={this.onMenuItemCick.bind(this)}
              />
              <Main 
                posts={this.state.posts}                
              />
            </div>     
        </div>
    </div>
    );
  }
}

export default App;
