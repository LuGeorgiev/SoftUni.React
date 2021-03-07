import { Component } from 'react';
import Book from './Book';

class BookList extends Component {
    constructor(props){
        super(props);
    } 

    bookClicked(title){
        console.log(`The book ${title} has been added to absket`);
    }

    render() {
        return (
            <div>
                <h2>Our book collection</h2>

                { this.props.books.map(book => {
                    return <Book 
                        title={book.title} 
                        description={book.description} 
                        //clickHandler={this.bookClicked.bind(this, book.title)}
                        clickHandler={() => this.bookClicked(book.title)}
                    />
                })}            
            </div>    
        )
    }
}

export default BookList;
