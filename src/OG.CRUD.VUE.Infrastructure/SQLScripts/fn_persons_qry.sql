-- FUNCTION: public.fn_persons_qry(integer)

-- DROP FUNCTION IF EXISTS public.fn_persons_qry(integer);

CREATE OR REPLACE FUNCTION public.fn_persons_qry(
	person_id integer DEFAULT NULL::integer)
    RETURNS SETOF "Persons" 
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
BEGIN
    RETURN QUERY SELECT * FROM public."Persons" WHERE "Id" = COALESCE(person_id, "Id");
END;
$BODY$;