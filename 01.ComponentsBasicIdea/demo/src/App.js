import './App.css';
import Body from './componnets/Body';
import BookList from './componnets/BookList';
import Counter from './componnets/Counter';
import Heading from './componnets/Heading';

const booksData =[
  { title:'Harry Potter', description:'wizzards for children' },
  { title:'Game of Thronse', description:'Best fantasy ever' },
  { title:'A man called Ove', description:'Graet fun!' },
  { title:'The Bible', description:'To Read' },
  { title: null, description:'very interesting' },
  { title:'Some book', description: undefined },
];

function App() {
  return (
    <div className="site-wrapper">
      <Counter/>
      <Counter/>
      <Heading>My custom library</Heading>
      <BookList books={booksData} />
      <Body/>
    </div>
  );
}

export default App;
