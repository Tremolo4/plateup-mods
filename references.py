from pathlib import Path
import sys

path = Path(sys.argv[1])

for dll in sorted(path.glob("*.dll")):
    print(
f"""<Reference Include="{dll.stem}">
  <SpecificVersion>False</SpecificVersion>
  <HintPath>$(UnityPath)\{dll.name}</HintPath>
  <Private>False</Private>
</Reference>""")
