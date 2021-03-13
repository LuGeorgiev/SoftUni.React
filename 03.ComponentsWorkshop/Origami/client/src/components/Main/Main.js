import './Main.css';
import Post from './Post/Post';

const Main = ({
    posts,
    onMenuItemCick
}) =>{
    return(
        <main className="main-wrapper">
            <h1>Some heading</h1>
            <div className="posts">
                {posts.map(x => 
                    <Post 
                        key={x.id}
                        content={x.content}
                        author={x.author}
                    />
                )}   
            </div>
        </main>
    );
}

export default Main;