
import { Link, Route, Switch } from 'react-router-dom';
import Nav from 'react-bootstrap/Nav'

import AllWorkouts from './Workout/AllWorkouts/AllWorkouts';
import WorkoutCreate from './Workout/WorkoutCreate/WorkoutCreate';
import WorkoutDetails from './Workout/WorkoutDetails/WorkoutDetails';
import WorkoutEdit from './Workout/WorkoutEdit/WorkoutEdit';
import AllExcercisese from './Excercise/AllExcercises/AllExcercises';
import ExcerciseCreate from './Excercise/ExcerciseCreate/ExcerciseCreate';
import ExcerciseDetails from './Excercise/ExcerciseDetails/ExcerciseDetails';
import ExcerciseEdit from './Excercise/ExcerciseEdit/ExcerciseEdit';
import AllWorkoutTypes from './WorkoutType/AllWorkoutTypes/AllWorkoutTypes';
import WorkoutTypeCreate from './WorkoutType/WorkoutTypeCreate/WorkoutTypeCreate';
import WorkoutTypeDetails from './WorkoutType/WorkoutTypeDetails/WorkoutTypeDetails';
import WorkoutTypeEdit from './WorkoutType/WorkoutTypeEdit/WorkoutTypeEdit';


const Main = () => {
    return (
        <>
            <Nav fill variant="tabs" defaultActiveKey="/excercises">
                <Nav.Item>
                    <Nav.Link as={Link} to="/workouts" eventKey="1">Workouts</Nav.Link>
                </Nav.Item>
                <Nav.Item>
                    <Nav.Link as={Link} to="/excercises" eventKey="2">Excercisese</Nav.Link>
                </Nav.Item>
                <Nav.Item>
                    <Nav.Link as={Link} to="/workout-types" eventKey="3">WorkoutTypes</Nav.Link>
                </Nav.Item>
            </Nav>
            <Switch>
                {/* <Route path="/create/workout" componnet={WorkoutCreate} />
                <Route path="/create/excercise" componnet={ExcerciseCreate} />
                <Route path="/create/workout-type" componnet={WorkoutTypeCreate} />
                <Route path="/edit/workout/:id" componnet={WorkoutEdit} />
                <Route path="/edit/excercise/:id" componnet={ExcerciseEdit} />
                <Route path="/edit/workout-type/:id" componnet={WorkoutTypeEdit} />
                <Route path="/details/workout/:id" componnet={WorkoutDetails} />
                <Route path="/details/excercise/:id" componnet={ExcerciseDetails} />
                <Route path="/details/workout-type/:id" componnet={WorkoutTypeDetails} /> */}
                <Route path="/workouts" component={AllWorkouts} />
                <Route path="/excercises" component={AllExcercisese} />
                <Route path="/workout-types" component={AllWorkoutTypes} />
            </Switch>
        </>
    );
}

export default Main;