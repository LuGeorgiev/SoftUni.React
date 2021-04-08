import './App.css';

import { Col, Container, Row } from 'react-bootstrap';

import Header from './components/Others/Header/Header';
import Aside from './components/Others/Aside/Aside';
import Footer from './components/Others/Footer/Footer';
import Main from './components/Main/Main';



function App() {
    return (
        <Container >
            <Row>
                <Header />
            </Row>
            <Row>
                <Col>
                    <Main sm={12} md={8} lg={8} xl={8}></Main>
                </Col>
                <Col>
                    <Aside sm={12} md={4} lg={4} xl={4}></Aside>
                </Col>
            </Row>
            <Row>
                <Footer></Footer>
            </Row>    
        </Container>

    );
}

export default App;
