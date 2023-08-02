import { Container } from "@mui/material";
import { createContext, useContext, useRef, useState } from "react";
import { useSwipeable } from "react-swipeable";

export interface SwipeEventHandler {
    handleSwipeLeft: () => void;
    handleSwipeRight: () => void;
}

const defaultSwipeEventHandler: SwipeEventHandler = {
  handleSwipeLeft: () => {},
  handleSwipeRight: () => {},
}

const SwipeContext = createContext<SwipeEventHandler>(defaultSwipeEventHandler);

export function useSwipeEvents() {
    return useContext(SwipeContext);
}

export function SwipeProvider({ children }: { children: React.ReactNode }) {
  const [swipeEventHandler ] = useState<SwipeEventHandler>(defaultSwipeEventHandler);
  const handlers = useSwipeable({ onSwiped: (e) => {
    if (e.dir === "Left") {
      swipeEventHandler.handleSwipeLeft();
    }
    else if (e.dir === 'Right') {
      swipeEventHandler.handleSwipeRight();
    }
  }});
  const myRef = useRef();

  const refPassthrough = (el:any) => {
    // call useSwipeable ref prop with el
    handlers.ref(el);

    // set myRef el so you can access it yourself
    myRef.current = el;
  }

  return (
    <Container {...handlers} ref={refPassthrough}>
      <SwipeContext.Provider value={swipeEventHandler}>
        {children}
      </SwipeContext.Provider>
    </Container>
  );
}