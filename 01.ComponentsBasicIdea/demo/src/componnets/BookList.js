import { Component } from 'react';
import Book from './Book';
import bookService from '../services/bookService';
import CircularProgress from '@material-ui/core/CircularProgress';

class BookList extends Component {
    constructor(props){
        super(props);

        this.state = {
            books:[]
        }
    } 

    bookClicked(title){
        console.log(`The book ${title} has been added to basket.`);
    }

    componentDidMount() {
        bookService.getAll()
            .then(books => {
                this.setState(() => ({ books }))
            });
    }

    render() {
        if (this.state.books.length === 0) {
              return  <CircularProgress />  
        }

        return (
            <div className="book-list">
                <h2> Our Book Collection</h2>

                {this.state?.books?.map((x, index) => 
                    <Book
                        key={x._id}
                        title={x.title}
                        description={x.description}
                        // clickHandler={this.bookClicked.bind(this, x.title)} 
                        clickHandler={() => this.bookClicked(x.title)}
                        author={x.author}
                    />
                )}

            </div>
        )
    }
}

export default BookList;
