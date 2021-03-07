function Book(props){
    if(!props.title){
        return(
            <article>
                <p>No information provided</p>
            </article>
        )
    }

    return (
        <article>
            <h3 onClick={props.clickHandler}>{props.title}</h3>
            <p>{props.description || 'Default descripton'}</p>
        </article>
    );
}

export default Book;