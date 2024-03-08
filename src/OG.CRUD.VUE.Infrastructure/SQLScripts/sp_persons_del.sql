-- PROCEDURE: public.sp_persons_del(integer)

-- DROP PROCEDURE IF EXISTS public.sp_persons_del(integer);

CREATE OR REPLACE PROCEDURE public.sp_persons_del(
	IN person_id integer)
LANGUAGE 'plpgsql'
AS $BODY$
BEGIN
    DELETE FROM public."Persons" WHERE "Id" = person_id;
END;
$BODY$;