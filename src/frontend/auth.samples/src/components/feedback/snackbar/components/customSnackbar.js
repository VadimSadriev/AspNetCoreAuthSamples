import React from 'react';
import { useSnackbar } from 'notistack';
import {
    Card,
    CardActions,
    Typography,
    IconButton
} from '@material-ui/core';
import { Close } from '@material-ui/icons';
import './style.scss'

const CustomSnackbar = React.forwardRef((props, ref) => {

    return (
        <Card className='custom-snackbar' ref={ref}>
            <CardActions>
                <Typography>{props.message}</Typography>
                <IconButton onClick={props.closeSnackbar}>
                    <Close fontSize='small' />
                </IconButton>
            </CardActions>
        </Card>
    )
})

export default CustomSnackbar;