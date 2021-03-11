import './App.css';
import Body from './componnets/Body';
import BookList from './componnets/BookList';
import Counter from './componnets/Counter';
import Footer from './componnets/Footer';
import Heading from './componnets/Heading';

function App() {
  return (
    <div className="site-wrapper">
        <Counter/>
        <Counter/>
        <Heading>My custom library</Heading>
        <BookList />
        <Body/>
        <Footer/>
    </div>
  );
}

export default App;
