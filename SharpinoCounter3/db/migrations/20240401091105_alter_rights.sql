-- migrate:up

GRANT ALL ON TABLE public.aggregate_events_01_counter TO safe;
GRANT ALL ON SEQUENCE public.aggregate_events_01_counter_id_seq to safe;
GRANT ALL ON TABLE public.events_01_counter to safe;
GRANT ALL ON TABLE public.snapshots_01_counter to safe;
GRANT ALL ON SEQUENCE public.snapshots_01_counter_id_seq to safe;
GRANT postgres to safe;    -- dangerous zone!!!! This is to allow at applicative level the classic optimistic lock aggregateState check.



-- migrate:down

